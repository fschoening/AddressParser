using AddressParser.NET.Impl.Parsing;
using AddressParser.NET.Impl.Testing;
using AddressParser.NET.Model.Interfaces;
using Ninject;

namespace AddressParser.NET.IoCBootstrap
{
    public static class IoCHelper
    {
		private static StandardKernel Init()
		{
			var _iocKernel = new StandardKernel();
			RegisterServices(_iocKernel);
			return _iocKernel;
		}

		public static void RegisterServices(IKernel kernel)
		{
			kernel.Bind<ITestDataLoader>().To<DefaultTestDataLoader>();
			kernel.Bind<IAddressParseService>().To<AddressParseService>();
		}

		public static ServiceWrapper GetDefaultServices()
		{
			var kernel = Init();
			var wrapper = new ServiceWrapper
				{
					DefaultITestDataLoader = kernel.Get<ITestDataLoader>(),
					DefaultIAddressParseService = kernel.Get<IAddressParseService>()
				};

			return wrapper;
		}
    }
}
