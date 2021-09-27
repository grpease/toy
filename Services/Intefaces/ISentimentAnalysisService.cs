using System;
using System.Collections.Generic;
using System.Text;

namespace Tendo.Services.Interfaces
{
    public interface ISentimentAnalysisService
    {
        float AnalyzeText(string text);
    }
}
