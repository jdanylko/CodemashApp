using System;
using System.Diagnostics;
using CodemashApp.Interfaces;
using StructureMap;
using StructureMap.Graph;

namespace CodemashApp.ViewModelBuilder
{
    public class DefaultViewModelFactory: IViewModelFactory
    {
        public TViewModel GetViewModel<TController, TViewModel>(TController controller)
        {
            // Ninject (slow)
            //using (var kernel = new StandardKernel())
            //{
            //    kernel.Bind(x => x.FromThisAssembly()
            //        .SelectAllClasses()
            //        .BindAllInterfaces());

            //    model = kernel.Get<TViewModel>();
            //    modelBuilder = kernel.Get<IViewModelBuilder<TController, TViewModel>>();
            //}

            // StructureMap (Faster)
            var container = new Container(_ =>
            {
                _.Scan(x =>
                {
                    x.TheCallingAssembly();
                    x.WithDefaultConventions();
                    x.AddAllTypesOf<IViewModelBuilder<TController, TViewModel>>();
                });
            });
            var model = container.GetInstance<TViewModel>();
            var modelBuilder = container.GetInstance<IViewModelBuilder<TController, TViewModel>>();

            // Redirect and assist developers in adding their own modelbuilder/viewmodel
            if (modelBuilder == null)
                throw new Exception(
                    String.Format(
                        "Could not find a ModelBuilder with a {0} Controller/{1} ViewModel pairing. Please create one.",
                        typeof (TController).Name, typeof (TViewModel).Name));
            
            return modelBuilder.Build(controller, model);
        }

        public TViewModel GetViewModel<TController, TViewModel, TInput>(TController controller, TInput data)
        {
            //using (var kernel = new StandardKernel())
            //{
            //    kernel.Bind(x => x.FromThisAssembly()
            //        .SelectAllClasses()
            //        .BindAllInterfaces());

            //    model = kernel.Get<TViewModel>();
            //    modelBuilder = kernel.Get<IViewModelBuilder<TController, TViewModel, TInput>>();
            //}

            // StructureMap (Faster)
            var container = new Container(_ =>
            {
                _.Scan(x =>
                {
                    x.TheCallingAssembly();
                    x.WithDefaultConventions();
                    x.AddAllTypesOf<IViewModelBuilder<TController, TViewModel, TInput>>();
                });
            });
            var model = container.GetInstance<TViewModel>();
            var modelBuilder = container.GetInstance<IViewModelBuilder<TController, TViewModel, TInput>>();

            // Redirect and assist developers in adding their own modelbuilder/viewmodel
            if (modelBuilder == null)
                throw new Exception(
                    String.Format(
                        "Could not find a ModelBuilder with a {0} Controller/{1} ViewModel/{2} TInput pairing. Please create one.",
                        typeof (TController).Name, typeof (TViewModel).Name, typeof (TInput).Name));

            return modelBuilder.Build(controller, model, data);
        }
    }
}