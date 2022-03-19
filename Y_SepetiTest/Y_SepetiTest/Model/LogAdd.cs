using System;
using Y_SepetiTest.Entities;

namespace Y_SepetiTest.Model
{
    public class LogAdd
    {
        TestLog logData = new TestLog();
        public void Add(string testId, string levelTxt, string processTxt, string message, string urlreq, string line, string exception)
        {
            var time = DateTime.Now.ToString("G");
            using (DataContext context = new DataContext())
            {
                logData.TestId = testId;
                logData.Data = time;
                logData.Level = levelTxt;
                logData.Process = processTxt;
                logData.Message = message;
                logData.URLRequest = urlreq;
                logData.RequestLine = line;
                logData.Exception = exception;
                context.testLog.Add(logData);
                context.SaveChanges();
            }
        }
    }
}
