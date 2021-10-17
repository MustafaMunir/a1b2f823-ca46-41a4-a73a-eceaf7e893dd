using System;
using System.Linq;

namespace IntSequenceString
{
    public class IntSequenceString
    {
        public string LongestIncreasingSubsequence(string intSequenceString)
        {
            int candidateSeqStartIndex = 0, scanningSeqStartIndex = 0;
            int candidateSeqFinshIndex = 0, scanningSeqFinishIndex = 0;

            int[] intSequenceArr = intSequenceString.Split(null).Select(x => int.Parse(x)).ToArray();

            for (int i = 0; i < intSequenceArr.Length; ++i){
                if ((i < intSequenceArr.Length - 1) && (intSequenceArr[i] < intSequenceArr[i + 1])) {
                    scanningSeqFinishIndex = i + 1;
                    continue;
                }
                else {
                    scanningSeqFinishIndex = i;
                }

                if ((candidateSeqFinshIndex - candidateSeqStartIndex) < (scanningSeqFinishIndex - scanningSeqStartIndex))
                {
                    candidateSeqFinshIndex = scanningSeqFinishIndex;
                    candidateSeqStartIndex = scanningSeqStartIndex;
                }

                scanningSeqStartIndex = scanningSeqFinishIndex = i + 1;
            }

            /* Extract the longest increasing sequence. */
            ArraySegment<int> segment = new ArraySegment<int>(intSequenceArr, candidateSeqStartIndex, (candidateSeqFinshIndex - candidateSeqStartIndex + 1));
            string result = String.Join(" ", segment.Select(p=>p.ToString()).ToArray());

            return result;
        }
    }
}
