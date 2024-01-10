namespace API.Controllers {
    //"Data Transfer Object". Ein DTO ist ein Objekt, das dazu dient, Daten zwischen Software-Anwendungen m
    //it unterschiedlichen Schnittstellen zu übertragen. Es ist eine Klasse, die nur Datenfelder enthält, aber
    //normalerweise keine geschäftlichen Logiken oder Methoden.
    public class LoginDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

}