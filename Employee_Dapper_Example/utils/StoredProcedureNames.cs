namespace Employee_Dapper_Example.utils
{
    public static class StoredProcedureNames
    {
        #region EmployeeStoredProcedure Details
        public static readonly string AddEmployee = "AddEmployee";
        public static readonly string UpdateEmployee = "UpdateEmployee";
        public static readonly string DeleteEmployee = "DeleteEmployee";
        public static readonly string GetAllEmployees = "GetAllEmployees";
        public static readonly string GetEmployeeById = "GetEmployeeById";
        #endregion

        #region OrderStoredProcedures
        public static readonly string AddOrder = "Usp_AddOrder";
        public static readonly string UpdateOrder = "Usp_UpdateOrder";
        public static readonly string DeleteOrder = "Usp_DeleteOrder";
        public static readonly string GetOrder = "Usp_GetOrder";
        public static readonly string GetOrderById = "Usp_GetOrderById";
        #endregion

        #region DepartmentDetails
        public static readonly string AddDepartment = "Usp_AddDepartment";
        public static readonly string UpdateDepartment = "Usp_UpdateDepartment";
        public static readonly string DeleteDepartment = "Usp_DeleteDepartment";
        public static readonly string GetDepartment = "Usp_GetDepartment";
        public static readonly string GetDepartmentByDeptId = "Usp_GetDepartmentById";
        #endregion
    }
}
