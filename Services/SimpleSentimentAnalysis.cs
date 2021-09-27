using System;
using System.Collections.Generic;
using System.Text;
using Tendo.Services.Interfaces;

namespace Tendo.Services
{
    public class SimpleSentimentAnalysis : ISentimentAnalysisService
    {
        public float AnalyzeText(string text)
        {
            float sentiment = .5F;
            if (text.Contains("Yes", StringComparison.OrdinalIgnoreCase))
                sentiment = 1;
            else if (text.Contains("No", StringComparison.OrdinalIgnoreCase))
                sentiment = .0F;
            return sentiment;
        }
    }
}
