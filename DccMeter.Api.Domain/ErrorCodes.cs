using Microsoft.AspNetCore.Http;

namespace DccMeter.Api.Domain
{
    public enum ErrorCodes
    {
        #region Basic

        /// <summary>
        /// Bad request.
        /// </summary>
        BadRequest = StatusCodes.Status400BadRequest,

        /// <summary>
        /// Unauthorized.
        /// </summary>
        Unauthorized = StatusCodes.Status401Unauthorized,

        /// <summary>
        /// Forbidden.
        /// </summary>
        Forbidden = StatusCodes.Status403Forbidden,

        /// <summary>
        /// Not found.
        /// </summary>
        NotFound = StatusCodes.Status404NotFound,

        /// <summary>
        /// Conflict.
        /// </summary>
        Conflict = StatusCodes.Status409Conflict,

        /// <summary>
        /// Internal server error.
        /// </summary>
        InternalServerError = StatusCodes.Status500InternalServerError,

        #endregion

        #region TestProject 10001-11000

        /// <summary>
        /// Test project not found.
        /// </summary>
        TestProjectNotFound = 10001,

        /// <summary>
        /// Test project registration failed.
        /// </summary>
        TestProjectRegistrationFailed = 10002,

        /// <summary>
        /// Test project modification failed.
        /// </summary>
        TestProjectModificationFailed = 10003,

        /// <summary>
        /// Test project image modification failed.
        /// </summary>
        TestProjectImageModificationFailed = 10004,

        /// <summary>
		/// Test project status not found.
		/// </summary>
        TestProjectStatusNotFound = 10005,


        /// <summary>
        /// Test project image modification failed.
        /// </summary>
        TestProjectStatusImageModificationFailed = 10006,

        /// <summary>
        /// Test Project Status name already Exists
        /// </summary>
        TestProjectStatusNameAlreadyExists = 10007,

        /// <summary>
        /// Test Project Status name not provided.
        /// </summary>
        TestProjectStatusNameNotProvided = 10008,

        /// <summary>
        /// Test Project Status TechnicalName already Exists
        /// </summary>
        TestProjectStatusTechnicalNameAlreadyExists = 10009,

        #endregion

        #region Test Settings 11001-12000

        /// <summary>
        /// Test type not found.
        /// </summary>
        TestTypeNotFound = 11001,

        /// <summary>
        /// Test category not found.
        /// </summary>
        TestCategoryNotFound = 11002,

        /// <summary>
        /// Test case status not found.
        /// </summary>
        TestCaseStatusNotFound = 11003,

        /// <summary>
        /// Test Plan Status not found.
        /// </summary>
        TestPlanStatusNotFound = 11004,

        /// <summary>
        /// Test priority not found.
        /// </summary>
        TestPriorityNotFound = 11005,

        /// <summary>
        /// Test status not found.
        /// </summary>
        TestStatusNotFound = 11006,

        ///////////////////////////////////---------------------------------------

        /// <summary>
        /// Test Type image modification failed.
        /// </summary>
        TestTypeImageModificationFailed = 11011,

        /// <summary>
        /// Test Category image modification failed.
        /// </summary>
        TestCategoryImageModificationFailed = 11012,

        /// <summary>
        /// Test Case Status image modification failed.
        /// </summary>
        TestCaseStatusImageModificationFailed = 11013,

        /// <summary>
        /// Test Plan Status image modification failed.
        /// </summary>
        TestPlanStatusImageModificationFailed = 11014,

        /// <summary>
        /// Test Priority image modification failed.
        /// </summary>
        TestPriorityImageModificationFailed = 11015,

        /// <summary>
        /// Test Status image modification failed.
        /// </summary>
        TestStatusImageModificationFailed = 11016,

        ///////////////////////////////////---------------------------------------

        /// <summary>
        /// Test Type name not provided.
        /// </summary>
        TestTypeNameNotProvided = 11101,

        /// <summary>
        /// Test Category name not provided.
        /// </summary>
        TestCategoryNameNotProvided = 11102,

        /// <summary>
        /// Test Priority name not provided.
        /// </summary>
        TestPriorityNameNotProvided = 11103,

        /// <summary>
        /// Test Project Status name not provided.
        /// </summary>
        TestProjectStatusTechnicalNameNotProvided = 11104,

        /// <summary>
        /// Test Case Status name not provided.
        /// </summary>
        TestCaseStatusNameNotProvided = 11105,

        /// <summary>
        /// Test Plan Status name not provided.
        /// </summary>
        TestPlanStatusNameNotProvided = 11106,

        /// <summary>
        /// Test Status name not provided.
        /// </summary>
        TestStatusNameNotProvided = 11107,


        ///////////////////////////////////---------------------------------------

        /// <summary>
        /// Test Status Technical name not provided.
        /// </summary>
        TestStatusTechnicalNameNotProvided = 11111,

        /// <summary>
        /// Test Plan Status Technical name not provided.
        /// </summary>
        TestPlanStatusTechnicalNameNotProvided = 11112,

        /// <summary>
        /// Test Case Status Technical name not provided.
        /// </summary>
        TestCaseStatusTechnicalNameNotProvided = 11113,

        /// <summary>
        /// Test Status Technical name  already Exists.
        /// </summary>
        TestStatusTechnicalNameAlreadyExists = 11114,

        /// <summary>
        /// Test CaseStatus Technical name  already Exists.
        /// </summary>
        TestCaseStatusTechnicalNameAlreadyExists = 11115,

        /// <summary>
        /// Test PlanStatusTechnical name  already Exists.
        /// </summary>
        TestPlanStatusTechnicalNameAlreadyExists = 11116,

        ///////////////////////////////////---------------------------------------

        /// <summary>
        /// Test Type name already Exists
        /// </summary>
        TestTypeNameAlreadyExists = 11117,

        /// <summary>
        /// Test Status name already Exists
        /// </summary>
        TestStatusNameAlreadyExists = 11118,

        /// <summary>
        /// Test Category name already Exists
        /// </summary>
        TestCategoryNameAlreadyExists = 11119,

        /// <summary>
        /// Test Priority name already Exists
        /// </summary>
        TestPriorityNameAlreadyExists = 11120,

        /// <summary>
        /// Test CaseStatus name already Exists
        /// </summary>
        TestCaseStatusNameAlreadyExists = 11121,

        /// <summary>
        /// Test PlanStatus name already Exists
        /// </summary>
        TestPlanStatusNameAlreadyExists = 11122,

        /// <summary>
        /// Test type deletion failed.
        /// </summary>
        TestTypeDeletionFailed = 11123,

        /// <summary>
        /// Test category deletion failed.
        /// </summary>
        TestCategoryDeletionFailed = 11124,

        /// <summary>
        /// Test priority deletion failed.
        /// </summary>
        TestPriorityDeletionFailed = 11125,

        /// <summary>
        /// Test status deletion failed.
        /// </summary>
        TestStatusDeletionFailed = 11126,

        #endregion


    }
}
