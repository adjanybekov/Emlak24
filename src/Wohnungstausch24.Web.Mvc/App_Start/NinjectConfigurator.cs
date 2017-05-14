using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Ninject;
using Ninject.Web.Common;
using Wohnungstausch24.DataAccess.Implementations;
using Wohnungstausch24.DataAccess.Interfaces;
using Wohnungstausch24.Migrations;
using Wohnungstausch24.Migrations.Security;
using Wohnungstausch24.Models.Entites;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Wohnungstausch24.Core.TypeMapping;
using Wohnungstausch24.Web.Mvc.AutoMappingConfiguration.DtoToDto;
using Wohnungstausch24.Web.Mvc.AutoMappingConfiguration.DtoToEntity;
using Wohnungstausch24.Web.Mvc.AutoMappingConfiguration.EntityToDto;


namespace Wohnungstausch24.Web.Mvc
{
    public class NinjectConfigurator
    {

        internal void Configure(StandardKernel kernel)
        {
            AddBindings(kernel);
        }
        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void AddBindings(IKernel kernel)
        {
            ConfigureAutoMapper(kernel);
            AddApplicationUserManagerBindings(kernel);

            kernel.Bind<IAuthManager>().To<AuthManager>();
            kernel.Bind<IAgentService>().To<AgentService>();
            kernel.Bind<ILocationService>().To<LocationService>();
            kernel.Bind<IListingService>().To<ListingService>();
            kernel.Bind<IFileService>().To<FileService>();
            kernel.Bind<IAgencyService>().To<AgencyService>();
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<ISearchService>().To<SearchService>();
            kernel.Bind<ISearchProfileService>().To<SearchProfileService>();
            kernel.Bind<IListingSecurityService>().To<ListingSecurityService>();
            kernel.Bind<IMailService>().To<MailService>();
        }

        private static void AddApplicationUserManagerBindings(IKernel kernel)
        {
            kernel.Bind<ApplicationDbContext>().ToSelf().InRequestScope();
            kernel.Bind<IUserStore<ApplicationUser>>()
                .To<UserStore<ApplicationUser>>()
                .WithConstructorArgument("context", kernel.Get<ApplicationDbContext>());
            ;
            kernel.Bind<UserManager<ApplicationUser>>().ToSelf();

            kernel.Bind<HttpContextBase>().ToMethod(ctx => new HttpContextWrapper(HttpContext.Current)).InTransientScope();

            kernel.Bind<ApplicationSignInManager>().ToMethod((context) =>
            {
                var cbase = new HttpContextWrapper(HttpContext.Current);
                return cbase.GetOwinContext().Get<ApplicationSignInManager>();
            });
            kernel.Bind<IAuthenticationManager>().ToMethod(c =>HttpContext.Current.GetOwinContext().Authentication).InRequestScope();
            kernel.Bind<ApplicationUserManager>().ToMethod(c =>HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>()).InRequestScope();
        }

        private static void ConfigureAutoMapper(IKernel kernel)
        {
            kernel.Bind<IAutoMapper>().To<AutoMapperAdapter>().InSingletonScope();
            kernel.Bind<IAutoMapperTypeConfigurator>().To<BalconyToBalconyViewModel>().InSingletonScope();
            kernel.Bind<IAutoMapperTypeConfigurator>().To<BalconyViewModelToBalcony>().InSingletonScope();
            kernel.Bind<IAutoMapperTypeConfigurator>().To<BathroomToBathroomViewModel>().InSingletonScope();
            kernel.Bind<IAutoMapperTypeConfigurator>().To<BathroomViewModelToBathroom>().InSingletonScope();
            kernel.Bind<IAutoMapperTypeConfigurator>().To<BeaconingToBeaconingViewModel>().InSingletonScope();
            kernel.Bind<IAutoMapperTypeConfigurator>().To<BeaconingViewModelToBeaconing>().InSingletonScope();
            kernel.Bind<IAutoMapperTypeConfigurator>().To<DetailListingToDetailDto>().InSingletonScope();
            kernel.Bind<IAutoMapperTypeConfigurator>().To<DistanceToDistanceToViewModel>().InSingletonScope();
            kernel.Bind<IAutoMapperTypeConfigurator>().To<DistanceViewModelToDistance>().InSingletonScope();
            kernel.Bind<IAutoMapperTypeConfigurator>().To<HeatingToHeatingViewModel>().InSingletonScope();
            kernel.Bind<IAutoMapperTypeConfigurator>().To<HeatingViewModelToHeating>().InSingletonScope();
            kernel.Bind<IAutoMapperTypeConfigurator>().To<ImageDtoToImage>().InSingletonScope();
            kernel.Bind<IAutoMapperTypeConfigurator>().To<ImageToImageDto>().InSingletonScope();
            kernel.Bind<IAutoMapperTypeConfigurator>().To<ListingsToStep1>().InSingletonScope();
            kernel.Bind<IAutoMapperTypeConfigurator>().To<ListingsToStep10>().InSingletonScope();
            kernel.Bind<IAutoMapperTypeConfigurator>().To<ListingsToStep2>().InSingletonScope();
            kernel.Bind<IAutoMapperTypeConfigurator>().To<ListingsToStep3>().InSingletonScope();
            kernel.Bind<IAutoMapperTypeConfigurator>().To<ListingsToStep4>().InSingletonScope();
            kernel.Bind<IAutoMapperTypeConfigurator>().To<ListingsToStep5>().InSingletonScope();
            kernel.Bind<IAutoMapperTypeConfigurator>().To<ListingsToStep6>().InSingletonScope();
            kernel.Bind<IAutoMapperTypeConfigurator>().To<ListingsToStep7>().InSingletonScope();
            kernel.Bind<IAutoMapperTypeConfigurator>().To<ListingsToStep8>().InSingletonScope();
            kernel.Bind<IAutoMapperTypeConfigurator>().To<ListingsToStep9>().InSingletonScope();
            kernel.Bind<IAutoMapperTypeConfigurator>().To<MixedLandToMLViewModel>().InSingletonScope();
            kernel.Bind<IAutoMapperTypeConfigurator>().To<MLViewModelToMixedLand>().InSingletonScope();
            kernel.Bind<IAutoMapperTypeConfigurator>().To<ObjectTextInAnotherLanguageToTextInAnotherLanguageViewModel>().InSingletonScope();
            kernel.Bind<IAutoMapperTypeConfigurator>().To<ParkingSpacesViewToParkingSpace>().InSingletonScope();
            kernel.Bind<IAutoMapperTypeConfigurator>().To<ParkingSpaceToParkingSpacesView>().InSingletonScope();
            kernel.Bind<IAutoMapperTypeConfigurator>().To<PersonToPersonViewModel>().InSingletonScope();
            kernel.Bind<IAutoMapperTypeConfigurator>().To<RangedNumbersToDto>().InSingletonScope();
            kernel.Bind<IAutoMapperTypeConfigurator>().To<RangedNumbersToEntity>().InSingletonScope();
            kernel.Bind<IAutoMapperTypeConfigurator>().To<SearchProfileToDto>().InSingletonScope();
            kernel.Bind<IAutoMapperTypeConfigurator>().To<SearchProfileToEntity>().InSingletonScope();
            kernel.Bind<IAutoMapperTypeConfigurator>().To<Step10ViewModelToListings>().InSingletonScope();
            kernel.Bind<IAutoMapperTypeConfigurator>().To<Step1ViewModelToListings>().InSingletonScope();
            kernel.Bind<IAutoMapperTypeConfigurator>().To<Step2ViewModelToListings>().InSingletonScope();
            kernel.Bind<IAutoMapperTypeConfigurator>().To<Step3ViewModelToListings>().InSingletonScope();
            kernel.Bind<IAutoMapperTypeConfigurator>().To<Step4ViewModelToListings>().InSingletonScope();
            kernel.Bind<IAutoMapperTypeConfigurator>().To<Step5ViewModelToListings>().InSingletonScope();
            kernel.Bind<IAutoMapperTypeConfigurator>().To<Step6ViewModelToListings>().InSingletonScope();
            kernel.Bind<IAutoMapperTypeConfigurator>().To<Step7ViewModelToListings>().InSingletonScope();
            kernel.Bind<IAutoMapperTypeConfigurator>().To<Step8ViewModelToListings>().InSingletonScope();
            kernel.Bind<IAutoMapperTypeConfigurator>().To<Step9ViewModelToListings>().InSingletonScope();
            kernel.Bind<IAutoMapperTypeConfigurator>().To<TextInAnotherLanguageViewModelToObjectTextInAnotherLanguage>().InSingletonScope();
            kernel.Bind<IAutoMapperTypeConfigurator>().To<ViewSightToViewSightViewModel>().InSingletonScope();
            kernel.Bind<IAutoMapperTypeConfigurator>().To<ViewSightViewModelToSight>().InSingletonScope();
            kernel.Bind<IAutoMapperTypeConfigurator>().To<AddNewClientViewModelToClient>().InSingletonScope();
            kernel.Bind<IAutoMapperTypeConfigurator>().To<ClientToClientViewModel>().InSingletonScope();
            kernel.Bind<IAutoMapperTypeConfigurator>().To<ClientViewModelToClient>().InSingletonScope();
        }
    }
}