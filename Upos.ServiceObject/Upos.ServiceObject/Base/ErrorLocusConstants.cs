namespace Upos.ServiceObject.Base
{
    public enum ErrorLocusConstants : int
    {
        /// <summary>
        /// Error occurred while processing asynchronous output
        /// </summary>
        Output = 1,

        /// <summary>
        /// Error occurred while gathering or processing eventdriven input. No previously buffered input data is available.
        /// </summary>
        Input = 2,

        /// <summary>
        /// Error occurred while gathering or processing eventdriven input, and some previously buffered data is available.
        /// </summary>
        Input_Data = 3
    }
}
