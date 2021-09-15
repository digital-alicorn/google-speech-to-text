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
    public class RecognizeRequest
    {
        /// <summary>
        /// Required. Provides information to the recognizer that specifies how to process the request.
        /// </summary>
        public RecognitionConfig Config { get; set; }

        /// <summary>
        /// Required. The audio data to be recognized.
        /// </summary>
        public RecognitionAudio Audio { get; set; }
    }

    public class RecognitionConfig
    {
        /// <summary>
        /// Encoding of audio data sent in all RecognitionAudio messages. This field is optional for FLAC and WAV audio files and required for all other audio formats.
        /// </summary>
        public string Encoding { get; set; }

        /// <summary>
        /// Sample rate in Hertz of the audio data sent in all RecognitionAudio messages. Valid values are: 8000-48000. 16000 is optimal. For best results, set the sampling rate of the audio source to 16000 Hz. If that's not possible, use the native sample rate of the audio source (instead of re-sampling). This field is optional for FLAC and WAV audio files, but is required for all other audio formats.
        /// </summary>
        public int? SampleRateHertz { get; set; }

        /// <summary>
        /// The number of channels in the input audio data. ONLY set this for MULTI-CHANNEL recognition. Valid values for LINEAR16 and FLAC are 1-8. Valid values for OGG_OPUS are '1'-'254'. Valid value for MULAW, AMR, AMR_WB and SPEEX_WITH_HEADER_BYTE is only 1. If 0 or omitted, defaults to one channel (mono). Note: We only recognize the first channel by default. To perform independent recognition on each channel set enableSeparateRecognitionPerChannel to 'true'.
        /// </summary>
        public int? AudioChannelCount { get; set; }

        /// <summary>
        /// This needs to be set to true explicitly and audioChannelCount > 1 to get each channel recognized separately. The recognition result will contain a channelTag field to state which channel that result belongs to. If this is not true, we will only recognize the first channel. The request is billed cumulatively for all channels recognized: audioChannelCount multiplied by the length of the audio.
        /// </summary>
        public bool? EnableSeparateRecognitionPerChannel { get; set; }

        /// <summary>
        /// Required. The language of the supplied audio as a BCP-47 language tag. Example: "en-US". See Language Support for a list of the currently supported language codes.
        /// </summary>
        public string LanguageCode { get; set; }

        /// <summary>
        /// Maximum number of recognition hypotheses to be returned. Specifically, the maximum number of SpeechRecognitionAlternative messages within each SpeechRecognitionResult. The server may return fewer than maxAlternatives. Valid values are 0-30. A value of 0 or 1 will return a maximum of one. If omitted, will return a maximum of one.
        /// </summary>
        public int? MaxAlternatives { get; set; }

        /// <summary>
        /// If set to true, the server will attempt to filter out profanities, replacing all but the initial character in each filtered word with asterisks, e.g. "f***". If set to false or omitted, profanities won't be filtered out.
        /// </summary>
        public bool? ProfanityFilter { get; set; }

        /// <summary>
        /// Array of SpeechContext. A means to provide context to assist the speech recognition. For more information, see <see cref="https://cloud.google.com/speech-to-text/docs/adaptation">speech adaptation</see>.
        /// </summary>
        public List<SpeechContext> SpeechContexts { get; set; }

        /// <summary>
        /// If true, the top result includes a list of words and the start and end time offsets (timestamps) for those words. If false, no word-level time offset information is returned. The default is false.
        /// </summary>
        public bool? EnableWordTimeOffsets { get; set; }

        /// <summary>
        /// If 'true', adds punctuation to recognition result hypotheses. This feature is only available in select languages. Setting this for requests in other languages has no effect at all. The default 'false' value does not add punctuation to result hypotheses.
        /// </summary>
        public bool? EnableAutomaticPunctuation { get; set; }

        /// <summary>
        /// Which model to select for the given request. Select the model best suited to your domain to get best results. If a model is not explicitly specified, then we auto-select a model based on the parameters in the RecognitionConfig.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Set to true to use an enhanced model for speech recognition. If useEnhanced is set to true and the model field is not set, then an appropriate enhanced model is chosen if an enhanced model exists for the audio.
        /// 
        /// If useEnhanced is true and an enhanced version of the specified model does not exist, then the speech is recognized using the standard version of the specified model.
        /// </summary>
        public bool? UseEnhanced { get; set; }
    }

    public static class AudioEncodings
    {
        /// <summary>
        /// Not specified.
        /// </summary>
        public const string EncodingUnspecified = "ENCODING_UNSPECIFIED";

        /// <summary>
        /// Uncompressed 16-bit signed little-endian samples (Linear PCM).
        /// </summary>
        public const string Linear16 = "LINEAR_16";

        /// <summary>
        /// FLAC (Free Lossless Audio Codec) is the recommended encoding because it is lossless--therefore recognition is not compromised--and requires only about half the bandwidth of LINEAR16. FLAC stream encoding supports 16-bit and 24-bit samples, however, not all fields in STREAMINFO are supported.
        /// </summary>
        public const string Flac = "FLAC";

        /// <summary>
        /// 8-bit samples that compand 14-bit audio samples using G.711 PCMU/mu-law.
        /// </summary>
        public const string Mulaw = "MULAW";

        /// <summary>
        /// Adaptive Multi-Rate Narrowband codec. sampleRateHertz must be 8000.
        /// </summary>
        public const string Amr = "AMR";

        /// <summary>
        /// Adaptive Multi-Rate Wideband codec. sampleRateHertz must be 16000.
        /// </summary>
        public const string AmrWb = "AMR_WB";

        /// <summary>
        /// Opus encoded audio frames in Ogg container (OggOpus). sampleRateHertz must be one of 8000, 12000, 16000, 24000, or 48000.
        /// </summary>
        public const string OggOpus = "OGG_OPUS";

        /// <summary>
        /// Although the use of lossy encodings is not recommended, if a very low bitrate encoding is required, OGG_OPUS is highly preferred over Speex encoding. The Speex encoding supported by Cloud Speech API has a header byte in each block, as in MIME type audio/x-speex-with-header-byte. It is a variant of the RTP Speex encoding defined in RFC 5574. The stream is a sequence of blocks, one block per RTP packet. Each block starts with a byte containing the length of the block, in bytes, followed by one or more frames of Speex data, padded to an integral number of bytes (octets) as specified in RFC 5574. In other words, each RTP header is replaced with a single byte containing the block length. Only Speex wideband is supported. sampleRateHertz must be 16000.
        /// </summary>
        public const string SpeexWithHeaderByte = "SPEEX_WITH_HEADER_BYTE";
    }

    public class SpeechContext
    {
        /// <summary>
        /// A list of strings containing words and phrases "hints" so that the speech recognition is more likely to recognize them. This can be used to improve the accuracy for specific words and phrases, for example, if specific commands are typically spoken by the user. This can also be used to add additional words to the vocabulary of the recognizer. See <see cref="https://cloud.google.com/speech-to-text/quotas#content">usage limits</see>.
        /// 
        /// List items can also be set to classes for groups of words that represent common concepts that occur in natural language.For example, rather than providing phrase hints for every month of the year, using the $MONTH class improves the likelihood of correctly transcribing audio that includes months.
        /// </summary>
        public List<string> Phrases { get; set; }
    }

    public static class RecognitionModels
    {
        /// <summary>
        /// Best for short queries such as voice commands or voice search.
        /// </summary>
        public const string CommandAndSearch = "command_and_search";

        /// <summary>
        /// Best for audio that originated from a phone call (typically recorded at an 8khz sampling rate).
        /// </summary>
        public const string PhoneCall = "phone_call";

        /// <summary>
        /// Best for audio that originated from video or includes multiple speakers. Ideally the audio is recorded at a 16khz or greater sampling rate. This is a premium model that costs more than the standard rate.
        /// </summary>
        public const string Video = "video";

        /// <summary>
        /// Best for audio that is not one of the specific audio models. For example, long-form audio. Ideally the audio is high-fidelity, recorded at a 16khz or greater sampling rate.
        /// </summary>
        public const string Default = "default";
    }

    public class RecognitionAudio
    {
        /// <summary>
        /// The audio data bytes encoded as specified in RecognitionConfig. Note: as with all bytes fields, proto buffers use a pure binary representation, whereas JSON representations use base64.
        ///
        /// A base64-encoded string.
        /// </summary>
        public string Content { get; set; }
    }
}
