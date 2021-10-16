using System;
using System.Linq;

namespace IntSequenceString
{
    public class IntSequenceString
    {
        public string LongestIncreasingSubsequence(string intSequenceString)
        {
            int lisStartIndex = 0, currentLisStartIndex = 0;
            int lisFinshIndex = 0, currentLisFinishIndex = 0;

            int[] intSequenceArr = intSequenceString.Split(null).Select(x => int.Parse(x)).ToArray();

            for (int i = 0; i < intSequenceArr.Length - 1; ++i){
                if (intSequenceArr[i] < intSequenceArr[i + 1] ) {
                    currentLisFinishIndex = i + 1;
                    continue;
                }
                else {
                    currentLisFinishIndex = i;
                }

                if ((lisFinshIndex - lisStartIndex) < (currentLisFinishIndex - currentLisStartIndex))
                {
                    lisFinshIndex = currentLisFinishIndex;
                    lisStartIndex = currentLisStartIndex;
                }

                currentLisStartIndex = currentLisFinishIndex = i + 1;
            }

            ArraySegment<int> segment = new ArraySegment<int>(intSequenceArr, lisStartIndex, (lisFinshIndex - lisStartIndex + 1));

            string result = String.Join(" ", segment.Select(p=>p.ToString()).ToArray());

            return result;
        }
    }
}
