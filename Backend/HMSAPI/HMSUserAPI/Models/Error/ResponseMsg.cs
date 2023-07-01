namespace HMSUserAPI.Models.Error
{
    public static class ResponseMsg
    {
        public static List<string> Messages;
        static ResponseMsg()
        {
            Messages = new List<string>()
            {
                "Somethiing went wrong",//0
                "Server not Working",//1
                "User not found",//2
                "Doctor not found",//3
                "Patient not found",//4
                "User Already Exists",//5
                "Unable to Register",//6
                "Invalid credentials",//7
                "No patient found",//8
                "No Doctor found",//9
                "Id should be unassigned",//10
                "Unable to Register",//11
                "Context is emyty"//12
            };

        }
    }
}
