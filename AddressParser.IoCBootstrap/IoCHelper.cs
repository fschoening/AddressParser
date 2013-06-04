using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressParser.Impl.Parsing;
using AddressParser.Impl.Testing;
using AddressParser.Model.Interfaces;
using Ninject;

namespace AddressParser.IoCBootstrap
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
