using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

public class GlobalValues
{
    private static List<LatestTradeCostModel> _lastValues;
    private static string _environment;
    private static string _currentFileDay = string.Empty;

    public GlobalValues(IConfiguration configuration) =>
        _environment = configuration["ASPNETCORE_ENVIRONMENT"];

    public static List<LatestTradeCostModel> LatestTradeCosts { 
        get {
            if(_lastValues == null || IsNewDate()) GetLastValues();

            return _lastValues;
        } 
    }

    private static bool IsNewDate()
    {
        if(_environment != "Production") return false;

        if(!_currentFileDay.Equals(GetCurentFileName()))
        {
            _currentFileDay = GetCurentFileName();
            return true;
        } else return false;
    }

    private static void GetLastValues()
    {
        string stringValues = GetValuesFromFlatFile();
        if(string.IsNullOrWhiteSpace(stringValues)) _lastValues = new List<LatestTradeCostModel>();
        else _lastValues = GetValuesFromJsonString(stringValues);
    }

    private static List<LatestTradeCostModel> GetValuesFromJsonString(string stringValues) =>
        JsonConvert.DeserializeObject<List<LatestTradeCostModel>>(stringValues);
    

    private static string GetValuesFromFlatFile()
    {
        var outPutDirectory = Path.GetDirectoryName(path: Assembly.GetExecutingAssembly().Location);
        string stringFile = string.Empty;

        try
        {
            if(_environment == "Production")
                stringFile = File.ReadAllText(Path.Combine(outPutDirectory, $"..\\..\\..\\FruitTrade.Api\\FlatFiles\\{_currentFileDay}.json"));
            else
                stringFile = File.ReadAllText(Path.Combine(outPutDirectory, "..\\..\\..\\..\\FruitTrade.Api\\FlatFiles\\20210931.json"));

        }
        catch (System.Exception)
        {
            // In production we need to send a business error
        }

        return stringFile;
    }

    private static string GetCurentFileName()
    {
        DateTime today = DateTime.Now;
        return $"{today.Year}{today.Month}{today.Day}";
    }
}