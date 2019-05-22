// ***********************************************************************
// Assembly         : TMS.Web
// Author           : Almas Shabbir
// Created          : 07-08-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 02-12-2018
// ***********************************************************************
// <copyright file="ResolveDI.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2014
// </copyright>
// <summary></summary>
// ***********************************************************************
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using TMS.Business.Admin;
using TMS.Business.CastleWindsor;
using TMS.Business.Common;
using TMS.Business.Common.Address;
using TMS.Business.Common.Configuration;
using TMS.Business.Common.DDL;
using TMS.Business.Common.Groups;
using TMS.Business.CRM;
using TMS.Business.Interfaces;
using TMS.Business.Interfaces.Admin;
using TMS.Business.Interfaces.Common;
using TMS.Business.Interfaces.Common.Address;
using TMS.Business.Interfaces.Common.Configuration;
using TMS.Business.Interfaces.Common.DDL;
using TMS.Business.Interfaces.Common.Groups;
using TMS.Business.Interfaces.CRM;
using TMS.Business.Interfaces.TMS;
using TMS.Business.Interfaces.TMS.Exams;
using TMS.Business.Interfaces.TMS.Language;
using TMS.Business.Interfaces.TMS.Organization;
using TMS.Business.Interfaces.TMS.Persons.Education;
using TMS.Business.Interfaces.TMS.Program;
using TMS.Business.Interfaces.TMS.SkillsInterestLevel;
using TMS.Business.TMS;
using TMS.Business.TMS.Exams;
using TMS.Business.TMS.Language;
using TMS.Business.TMS.Organization;
using TMS.Business.TMS.Persons.Contact;
using TMS.Business.TMS.Persons.Education;
using TMS.Business.TMS.Program;
using TMS.Business.TMS.Report;
using TMS.Business.TMS.SkillsInterestLevel;

namespace TMS.Web.App_Start
{
    /// <summary>
    /// Class InitializeAllInterfaceDI.
    /// </summary>
    /// <seealso cref="Castle.MicroKernel.Registration.IWindsorInstaller" />
    public class InitializeAllInterfaceDI : IWindsorInstaller
    {
        /// <summary>
        /// Performs the installation in the <see cref="T:Castle.Windsor.IWindsorContainer" />.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="store">The configuration store.</param>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<ILookupBAL>().ImplementedBy<LookupBAL>().LifestyleTransient(),
                Component.For<ITMSResourcesBAL>().ImplementedBy<TMSResourcesBAL>().LifestyleTransient(),
                Component.For<IOrganizationBAL>().ImplementedBy<OrganizationBAL>().LifestyleTransient(),
                Component.For<IAttachmentBAL>().ImplementedBy<AttachmentBAL>().LifestyleTransient(),
                Component.For<IPersonBAL>().ImplementedBy<PersonBAL>().LifestyleTransient(),
                Component.For<IPersonEducationBAL>().ImplementedBy<PersonEducationBAL>().LifestyleTransient(),
                Component.For<IDDLBAL>().ImplementedBy<DDLBAL>().LifestyleTransient(),
                Component.For<IAddressBAL>().ImplementedBy<AddressBAL>().LifestyleTransient(),
                Component.For<IPersonContactBAL>().ImplementedBy<PersonContactBAL>().LifestyleTransient(),
                Component.For<ISkillsInterestLevelBAL>().ImplementedBy<SkillsInterestLevelBAL>().LifestyleTransient(),
                Component.For<IBALUsers>().ImplementedBy<BALUsers>().LifestyleTransient(),
                Component.For<ICommonBAL>().ImplementedBy<CommonBAL>().LifestyleTransient(),
                Component.For<IGroupsBAL>().ImplementedBy<GroupsBAL>().LifestyleTransient(),
                Component.For<ICurrentUserClaims>().ImplementedBy<CurrentUserClaims>().LifestyleTransient(),
                Component.For<IOffice365UsersBAL>().ImplementedBy<Office365UsersBAL>().LifestyleTransient(),
                Component.For<ICourseBAL>().ImplementedBy<CourseBAL>().LifestyleTransient(),
                Component.For<IClassBAL>().ImplementedBy<ClassBAL>().LifestyleTransient(),
                Component.For<IConfigurationBAL>().ImplementedBy<ConfigurationBAL>().LifestyleTransient(),
                Component.For<ISessionBAL>().ImplementedBy<SessionBAL>().LifestyleTransient(),
                Component.For<IRolesBAL>().ImplementedBy<RolesBAL>().LifestyleTransient(),
                Component.For<IExamsBAL>().ImplementedBy<ExamsBAL>().LifestyleTransient(),
                Component.For<IBALTask>().ImplementedBy<BALTask>().LifestyleTransient(),
                Component.For<IProspectBAL>().ImplementedBy<ProspectBAL>().LifestyleTransient(),
                Component.For<IReportBAL>().ImplementedBy<ReportBAL>().LifestyleTransient(),
                Component.For<ITrainerBAL>().ImplementedBy<TrainerBAL>().LifestyleTransient(),
                   Component.For<ILanguageBAL>().ImplementedBy<LanguageBAL>().LifestyleTransient(),
                   Component.For<IAttendanceBAL>().ImplementedBy<AttendanceBAL>().LifestyleTransient(),
                      Component.For<ISalesAdministrationBAL>().ImplementedBy<SalesAdministrationBAL>().LifestyleTransient()

                );//
            container.Install(new DependencyInjectionExtension());
        }
    }
}