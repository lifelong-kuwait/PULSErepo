// ***********************************************************************
// Assembly         : TMS.Business
// Author           : Almas
// Created          : 07-16-2017
//
// Last Modified By : Almas
// Last Modified On : 07-16-2017
// ***********************************************************************
// <copyright file="DependencyInjectionBALUserExtension.cs" company="">
//     Copyright ©  2016
// </copyright>
// <summary>this is the dependency resolving in Business Layer which is Refereed in main web project</summary>
// ***********************************************************************
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using TMS.DataObjects.Interfaces.TMS;
using TMS.DataObjects.TMS;

namespace TMS.Business.CastleWindsor
{
    /// <summary>
    /// Class DependencyInjectionBALUserExtension.
    /// </summary>
    /// <seealso cref="Castle.MicroKernel.Registration.IWindsorInstaller" />
    public class DependencyInjectionBALUserExtension : IWindsorInstaller
    {
        /// <summary>
        /// Performs the installation in the <see cref="T:Castle.Windsor.IWindsorContainer" />.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="store">The configuration store.</param>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                  Component.For<IOffice365UsersDAL>().ImplementedBy<Office365UsersDAL>().LifestyleSingleton()
                );
        }
    }
}