// Sample raw input from analyzer: "ID:1001;GLUCOSE:5.6;WBC:8.4"
// Convert it to Dictionary<string, string>

using System;
using System.Collections.Generic;

public Dictionary<string, string> ParseLabResult(string rawInput)
{
    var result = new Dictionary<string, string>();

    if (string.IsNullOrEmpty(rawInput))
    {
        return result;
    }

    //split the input string by semicolon
    var pairs = rawInput.Split(';', StringSplitOptions.RemoveEmptyEntries);

    foreach (var pair in pairs)
    {
        //split each pair by colon
        var keyValue = pair.Split(':', StringSplitOptions.RemoveEmptyEntries);
        if (keyValue.Length == 2)
        {
            //trim whitespace and add to dictionary
            result[keyValue[0].Trim()] = keyValue[1].Trim();
        }
    }

    return result;
}

