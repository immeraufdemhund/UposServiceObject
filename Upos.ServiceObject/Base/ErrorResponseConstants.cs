namespace Upos.ServiceObject.Base
{
    public enum ErrorResponseConstants : int
    {
        /// <summary>
        /// Typically valid only when locus is OPOS_EL_OUTPUT.
        /// Retry the asynchronous output. The error state is exited.
        /// May be valid when locus is OPOS_EL_INPUT.
        /// Default when locus is OPOS_EL_OUTPUT.
        /// </summary>
        Retry = 11,

        /// <summary>
        /// Clear all buffered output data (including all asynchronous output) or buffered input data.
        /// The error state is exited.
        /// Default when locus is OPOS_EL_INPUT
        /// </summary>
        Clear = 12,

        /// <summary>
        /// Use only when locus is OPOS_EL_INPUT_DATA.
        /// Acknowledges the error and directs the Control to
        /// continue processing. The Control remains in the error
        /// state and will deliver additional DataEvents as directed
        /// by the DataEventEnabled property. When all input has
        /// been delivered and the DataEventEnabled property is
        /// again set to TRUE, then another ErrorEvent is
        /// delivered with locus OPOS_EL_INPUT.
        /// Default when locus is OPOS_EL_INPUT_DATA.
        /// </summary>
        ContinueInput = 13
    }
}
