using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA.Models.Models
{
    public static class ClaimData
    {
        public static List<string> AppClaims { get; set; } = new List<string>
        {
            "AddNewUser",
            "EditUserInformation",
            "ChangeUserPassword",
            "ResetUserPassword",
            "ViewListOfUsers",
            "AssignATillAccountToAUser",
            "ViewListOfTellers",
            "AddANewCustomer",
            "EditCustomerInfo",
            "ViewListOfAllCustomers",
            "AddANewCustomerAccount",
            "EditACustomerAccount",
            "CloseAccount",
            "ViewListOfAllCustomerAccounts",
            "EditTheSavingsAccountTypeConfiguration",
            "EditTheCurrentAccountTypeConfiguration",
            "EditTheLoanAccountTypeConfiguration",
            "AddNewGLCategory",
            "EditGLCategory",
            "ViewExistingGLCategories",
            "AddNewGLAccount",
            "EditGLAccounts",
            "ViewExistingGLAccounts",
            "PostTransactionIntoGLs",
            "ViewListOfGLPostings",
            "PostTransactionsIntoCustomerAccounts",
            "ViewListOfTellerPostings",
            "GenerateAndViewPandLReport",
            "GenerateAndViewBalanceSheetReport",
            "TrialBalance",
            "CloseBusiness",
            "OpenBusiness",
            "ManageRoles"
        };

        public static string ClaimType = "DynamicClaim";
    }
}