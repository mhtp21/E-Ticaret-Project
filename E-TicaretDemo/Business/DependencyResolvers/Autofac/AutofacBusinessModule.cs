﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Concrete;
using Business.Abstract;
using Business.Concerete;
using DataAccess.Abstract;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<EfProductDal>().As<IProductDal>();

            builder.RegisterType<BrandManager>().As<IBrandService>();
            builder.RegisterType<EfBrandDal>().As<IBrandDal>();

            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();

            builder.RegisterType<CityManager>().As<ICityService>();
            builder.RegisterType<EfCityDal>().As<ICityDal>();

            builder.RegisterType<CountryManager>().As<ICountryService>();
            builder.RegisterType<EfCountryDal>().As<ICountryDal>();

            builder.RegisterType<AddressManager>().As<IAddressService>();
            builder.RegisterType<EfAddressDal>().As<IAddressDal>();

            builder.RegisterType<OrderDetailsManager>().As<IOrderDetailsService>();
            builder.RegisterType<EfOrderDetailsDal>().As<IOrderDetailsDal>();

            builder.RegisterType<OrderManager>().As<IOrderService>();
            builder.RegisterType<EfOrderDal>().As<IOrderDal>();

            builder.RegisterType<OrderStatusManager>().As<IOrderStatusService>();
            builder.RegisterType<EfOrderDal>().As<IOrderDal>();

            builder.RegisterType<PaymentManager>().As<IPaymentService>();
            builder.RegisterType<EfPaymentDal>().As<IPaymentDal>();

            builder.RegisterType<CustomerCreditCardManager>().As<ICustomerCreditCardService>();
            builder.RegisterType<EfCustomerCreditCardDal>().As<ICustomerCreditCardDal>();

            builder.RegisterType<CustomerAddressManager>().As<ICustomerAddressService>();
            builder.RegisterType<EfCustomerAddressDal>().As<ICustomerAddressDal>();

            builder.RegisterType<BasketManager>().As<IBasketService>();
            builder.RegisterType<EfBasketDal>().As<IBasketDal>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<ProductImagesManager>().As<IProductImagesService>().SingleInstance();
            builder.RegisterType<EfProductImageDal>().As<IProductImageDal>().SingleInstance();

            builder.RegisterType<UserCommentManager>().As<IUserCommentService>().SingleInstance();
            builder.RegisterType<EfUserCommentDal>().As<IUserCommentDal>().SingleInstance();

            builder.RegisterType<UserOperationClaimManager>().As<IUserOperationClaimService>().SingleInstance();
            builder.RegisterType<EfUserOperationClaimDal>().As<IUserOperationClaimDal>().SingleInstance();

            builder.RegisterType<FavoriteManager>().As<IFavoriteService>().SingleInstance();
            builder.RegisterType<EfFavoriteDal>().As<IFavoriteDal>().SingleInstance();

            builder.RegisterType<JwtHelper>().As<ITokenHelper>();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
