using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OebbGoogle.SpeechToText.Models
{
    /// <summary>
    /// Documentation from: https://cloud.google.com/speech-to-text/docs/reference/rest/v1/speech/recognize
    /// </summary>
    public class RecognizeResponse
    {
        /// <summary>
        /// Sequential list of transcription results corresponding to sequential portions of audio.
        /// </summary>
        public List<SpeechRecognitionResults> Results { get; set; }

        /// <summary>
        /// When available, billed audio seconds for the corresponding request.
        ///
        /// A duration in seconds with up to nine fractional digits, terminated by 's'. Example: "3.5s".
        /// </summary>
        public string TotalBilledTime { get; set; }
    }

    public class SpeechRecognitionResults
    {
        /// <summary>
        /// May contain one or more recognition hypotheses (up to the maximum specified in maxAlternatives). These alternatives are ordered in terms of accuracy, with the top (first) alternative being the most probable, as ranked by the recognizer.
        /// </summary>
        public List<SpeechRecognitionAlternative> Alternatives { get; set; }

        /// <summary>
        /// For multi-channel audio, this is the channel number corresponding to the recognized result for the audio from that channel. For audioChannelCount = N, its output values can range from '1' to 'N'.
        /// </summary>
        public int ChannelTag { get; set; }
    }

    public class SpeechRecognitionAlternative
    {
        /// <summary>
        /// Transcript text representing the words that the user spoke.
        /// </summary>
        public string Transcript { get; set; }

        /// <summary>
        /// The confidence estimate between 0.0 and 1.0. A higher number indicates an estimated greater likelihood that the recognized words are correct. This field is set only for the top alternative of a non-streaming result or, of a streaming result where isFinal=true. This field is not guaranteed to be accurate and users should not rely on it to be always provided. The default of 0.0 is a sentinel value indicating confidence was not set.
        /// </summary>
        public double Confidence { get; set; }
    }
}
