using Flora.BusinessLayer.Abstract;
using Flora.BusinessLayer.Concrete;
using Flora.DataAccessLayer.Abstract;
using Flora.DataAccessLayer.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flora.BusinessLayer.Services
{
    public static class ServiceRegistration
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
           services.AddScoped<IAboutService, AboutManager>();
           services.AddScoped<IAboutDal, EfAboutDal>();

            services.AddScoped<IBookingService, BookingManager>();
            services.AddScoped<IBookingDal,EfBookingDal>();

            services.AddScoped<ICategoryService,CategoryManager>();
            services.AddScoped<ICategoryDal,EfCategoryDal>();

            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<IContactDal,EfContactDal>();

            services.AddScoped<IDiscountService, DiscountManager>();
            services.AddScoped<IDiscountDal,EfDiscountDal>();

            services.AddScoped<IFeatureService, FeatureManager>();
            services.AddScoped<IFeatureDal,EfFeatureDal>();

            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IProductDal,EfProductDal>();

            services.AddScoped<ISocialMediaService,SocialMediaManager>();
            services.AddScoped<ISocialMediaDal,EfSocialMediaDal>();

            services.AddScoped<ITestimonialService, TestimonialManager>();
            services.AddScoped<ITestimonialDal,EfTestimonialDal>();

            services.AddScoped<IOrderService, OrderManager>();
            services.AddScoped<IOrderDal, EfOrderDal>();

            services.AddScoped<IOrderDetailService, OrderDetailManager>();
            services.AddScoped<IOrderDetailDal, EfOrderDetailDal>();

            services.AddScoped<IMoneyCaseService, MoneyCaseManager>();
            services.AddScoped<IMoneyCaseDal, EfMoneyCaseDal>();

            services.AddScoped<IMenuTableService, MenuTableManager>();
            services.AddScoped<IMenuTableDal, EfMenuTableDal>();
        }
    }
}
