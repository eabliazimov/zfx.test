using System.Collections;

namespace Zfx.Test.Application.Features
{
    public class ConsoleStringLines : IEnumerable<string>
    {
        private readonly IList<string> _strings;

        public ConsoleStringLines()
        {
            _strings = new List<string>();
        }

        public ConsoleStringLines(string[] lines)
        {
            _strings = new List<string>(lines);
        }

        public void AppendLine(string line)
        {
            _strings.Add(line);
        }

        public IEnumerator<string> GetEnumerator()
        {
            return _strings.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
