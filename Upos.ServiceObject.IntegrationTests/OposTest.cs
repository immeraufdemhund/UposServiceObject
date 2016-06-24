using System;
using FluentAssertions;
using NUnit.Framework;
using OPOSCONSTANTSLib;
using OposMSR_CCO;

namespace Upos.ServiceObject.IntegrationTests
{
    [TestFixture]
    public class OposTest
    {
        private OPOSMSR msr;
        [SetUp]
        public void Setup()
        {
            msr = new OPOSMSR();
        }

        [TearDown]
        public void TearDown()
        {
            msr.Close();
            msr = null;
        }

        [Test]
        public void CanOpenTestMsrServiceObject()
        {
            var openResult = msr.Open("DemoMsr");
            CheckOpenResultCode((OpenResultCodes)msr.OpenResult);
            ((SucessCodes)openResult).ShouldBeEquivalentTo(SucessCodes.Success);
        }

        private void CheckOpenResultCode(OpenResultCodes openResult)
        {
            switch (openResult)
            {
                case OpenResultCodes.AlreadyOpen:
                    throw new Exception("Control already open.");
                case OpenResultCodes.RegBadName:
                    throw new Exception("The registry does not contain a key for the specified device name.");
                case OpenResultCodes.RegProgId:
                    throw new Exception("Could not read the device name key's default value, or could not convert the Programmatic ID it holds into a valid Class ID");
                case OpenResultCodes.Create:
                    throw new Exception("Could not create a service object instance, or could not get its IDispatch interface");
                case OpenResultCodes.BadInterface:
                    throw new Exception("The service object does not support one or more of the methods required by its release");
                case OpenResultCodes.Failed:
                    throw new Exception("The service object returned a failure status from its open call, but does not have a more specific failure code.");
                case OpenResultCodes.BadVersion:
                    throw new Exception("The service object major version number does not match the control object major version number. The following values can be returned by the Service Object if it returns a failure status from its open call. The Service Object can choose to return one of these, if applicable, or define additional values. (See the Control Programmer's Guide's GetOpenResult description for details on how the Service Object returns these values. If the Service Object does not implement GetOpenResult, then OpenResult returns OPOS_OR_FAILEDOPEN.) <SOVersion:" + msr.ServiceObjectVersion + ">");
                case OpenResultCodes.NoPort:
                    throw new Exception("The Service Object tried to access an I/O port (for example, an RS232 port) during Open processing, but the port that is configured for the DeviceName is invalid or inaccessible. As a general rule, an SO should refrain from accessing the physical device until the DeviceEnabled property is set to TRUE. But in some cases, it may require some access at Open; for instance, to dynamicallydetermining the device type in order to set the DeviceName and DeviceDescription properties.");
                case OpenResultCodes.NotSupported:
                    throw new Exception("The Service Object does not support the specified device.  The SO has determined that it does not have the ability  to control the device it is opening. This determination  may be due to an inspection of the registry entries for the device, or dynamic querying of the device during  open processing.");
                case OpenResultCodes.Config:
                    throw new Exception("Configuration information error. Usually this is due to incomplete configuration of the registry, such that the SO does not have sufficient or valid data to open the device.");
                case OpenResultCodes.Specific:
                    throw new Exception("Errors greater than this value are service objectspecific. If the previous return values do not apply, then the SO may define additional OpenResult values. These values are Service Object-specific, but may be of value in these cases: 1) The Application logs or reports this error during debug and testing. 2) The Application adds SO-specific logic, to attempt to report more error conditions or to recover from them.");
                case 0: //opos success
                    break;
                default:
                    throw new Exception("Unknown opos error:" + openResult);
            }
        }

        private enum SucessCodes
        {
            Success = OPOS_Constants.OPOS_SUCCESS,
            Closed = OPOS_Constants.OPOS_E_CLOSED,
            Claimed = OPOS_Constants.OPOS_E_CLAIMED,
            NotClaimed = OPOS_Constants.OPOS_E_NOTCLAIMED,
            NoService = OPOS_Constants.OPOS_E_NOSERVICE,
            Disabled = OPOS_Constants.OPOS_E_DISABLED,
            Illegal = OPOS_Constants.OPOS_E_ILLEGAL,
            NoHardware = OPOS_Constants.OPOS_E_NOHARDWARE,
            Offline = OPOS_Constants.OPOS_E_OFFLINE,
            NoExist = OPOS_Constants.OPOS_E_NOEXIST,
            Exists = OPOS_Constants.OPOS_E_EXISTS,
            Fail = OPOS_Constants.OPOS_E_FAILURE,
            Timeout = OPOS_Constants.OPOS_E_TIMEOUT,
            Busy = OPOS_Constants.OPOS_E_BUSY,
            Extended = OPOS_Constants.OPOS_E_EXTENDED,
            Deprecated = OPOS_Constants.OPOS_E_DEPRECATED,
        }

        private enum OpenResultCodes
        {
            AlreadyOpen = OPOS_Constants.OPOS_OR_ALREADYOPEN,
            RegBadName = OPOS_Constants.OPOS_OR_REGBADNAME,
            RegProgId = OPOS_Constants.OPOS_OR_REGPROGID,
            Create = OPOS_Constants.OPOS_OR_CREATE,
            BadInterface = OPOS_Constants.OPOS_OR_BADIF,
            Failed = OPOS_Constants.OPOS_OR_FAILEDOPEN,
            BadVersion = OPOS_Constants.OPOS_OR_BADVERSION,
            NoPort = OPOS_Constants.OPOS_ORS_NOPORT,
            NotSupported = OPOS_Constants.OPOS_ORS_NOTSUPPORTED,
            Config = OPOS_Constants.OPOS_ORS_CONFIG,
            Specific = OPOS_Constants.OPOS_ORS_SPECIFIC,
        }
    }
}
