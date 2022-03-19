using System.Collections.Generic;
using System.Linq;
using Y_SepetiTest.Entities;

namespace Y_SepetiTest.Model
{
    public class GetData
    {
        public void Data(string CreateTestId, out List<TestLog> Liste)
        {
            using (DataContext context = new DataContext())
            {
                Liste = (context.testLog.Where(i => i.TestId == CreateTestId)).ToList();
            }
        }
    }
}
