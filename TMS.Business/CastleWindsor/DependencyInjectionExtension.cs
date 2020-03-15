// ***********************************************************************
// Assembly         : TMS.Business
// Author           : Almas
// Created          : 07-08-2017
//
// Last Modified By : Almas
// Last Modified On : 02-10-2018
// ***********************************************************************
// <copyright file="DependencyInjectionExtension.cs" company="">
//     Copyright ©  2016
// </copyright>
// <summary>how the dependency will resolve against the cross ponding interfaces</summary>
// ***********************************************************************
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using TMS.DataObjects;
using TMS.DataObjects.Common;
using TMS.DataObjects.Common.Configuration;
using TMS.DataObjects.Common.Groups;
using TMS.DataObjects.Interfaces;
using TMS.DataObjects.Interfaces.Common;
using TMS.DataObjects.Interfaces.Common.Configuration;
using TMS.DataObjects.Interfaces.Common.Groups;
using TMS.DataObjects.Interfaces.Common.DDL;
using TMS.DataObjects.Interfaces.TMS;
using TMS.DataObjects.Interfaces.TMS.Exams;
using TMS.DataObjects.Interfaces.TMS.Organization;
using TMS.DataObjects.Interfaces.TMS.Program;
using TMS.DataObjects.TMS;
using TMS.DataObjects.TMS.Exams;
using TMS.DataObjects.TMS.Organization;
using TMS.DataObjects.TMS.Program;
using TMS.DataObjects.Common.DDL;
using TMS.DataObjects.TMS.Prospect;
using TMS.DataObjects.TMS.Task;
using TMS.DataObjects.TMS.Trainers;
using TMS.DataObjects.TMS.Language;
using TMS.Business.TMS.Language;
using TMS.DataObjects.CRM;
using TMS.DataObjects.Interfaces.CRM;

namespace TMS.Business.CastleWindsor
{
    /// <summary>
    /// Class DependencyInjectionExtension.
    /// </summary>
    /// <seealso cref="Castle.MicroKernel.Registration.IWindsorInstaller" />
    public class DependencyInjectionExtension : IWindsorInstaller
    {
        /// <summary>
        /// Performs the installation in the <see cref="T:Castle.Windsor.IWindsorContainer" />.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="store">The configuration store.</param>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                  Component.For<IUserDAL>().ImplementedBy<UserDAL>().LifestyleTransient(),
                  Component.For<IOrganizationDAL>().ImplementedBy<OrganizationDAL>().LifestyleTransient(),
                  Component.For<IGroupsDAL>().ImplementedBy<GroupsDAL>().LifestyleTransient(),
                  Component.For<IOffice365UsersDAL>().ImplementedBy<Office365UsersDAL>().LifestyleTransient(),
                  Component.For<ICourseDAL>().ImplementedBy<CourseDAL>().LifestyleTransient(),
                  Component.For<IClassDAL>().ImplementedBy<ClassDAL>().LifestyleTransient(),
                  Component.For<ISessionDAL>().ImplementedBy<SessionDAL>().LifestyleTransient(),
                  Component.For<IConfigurationDAL>().ImplementedBy<ConfigurationDAL>().LifestyleTransient(),
                  Component.For<IRolesDAL>().ImplementedBy<RolesDAL>().LifestyleTransient(),
                  Component.For<IExamsDAL>().ImplementedBy<ExamsDAL>().LifestyleTransient(),
                  Component.For<ITaskDAL>().ImplementedBy<TaskDAL>().LifestyleTransient(),
                  Component.For<IProspectDAL>().ImplementedBy<ProspectDAL>().LifestyleTransient(),
                  Component.For<IReportDAL>().ImplementedBy<ReportDAL>().LifestyleTransient(),
                  Component.For<ITrainerDAL>().ImplementedBy<TrainerDAL>().LifestyleTransient(),
                  Component.For<IDDLDAL>().ImplementedBy<DDLDAL>().LifestyleTransient(),              
                  Component.For<IAttendanceDAL>().ImplementedBy<AttendanceDAL>().LifestyleTransient(),
                  Component.For<ILanguageDAL>().ImplementedBy<LanguageDAL>().LifestyleTransient(),
                   Component.For<ISalesAdministrationDAL>().ImplementedBy<SalesAdministrationDAL>().LifestyleTransient(),
                   Component.For<INotificationsDAL>().ImplementedBy<INotificationsDAL>().LifestyleTransient()

                //
                );
        }
    }
}