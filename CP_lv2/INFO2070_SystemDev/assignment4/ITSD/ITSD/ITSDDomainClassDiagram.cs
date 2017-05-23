/* ITSDDomainClassDiagram.cs
 * ITSD Domain Class Diagram
 *
 * Revision History:
 *     Generated 4/8/2016 9:21:54 AM
 */

using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSD
{
    /// <summary>
    /// BusinessImpact class
    /// </summary>
    public class BusinessImpact : IComparable
    {
        private string name;

        /// <summary>
        /// Name property
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
               name = value;
            }
        }

        /// <summary>
        /// Compare this BusinessImpact object to another for sorting
        /// </summary>
        /// <param name="compareObject">Object to compare with this one</param>
        /// <returns>A negative number, 1, or a positive integer</returns>
        public int CompareTo(Object compareObject)
        {
            BusinessImpact compareBusinessImpact = (BusinessImpact) compareObject;

            string thisKey = "Change to the desired key";
            string compareKey = "Change to the desired key";

            return thisKey.CompareTo(compareKey);
        }

        /// <summary>
        /// Return a string that shows the current state of this BusinessImpact object
        /// </summary>
        /// <returns>Object state</returns>
        public override string ToString()
        {
            StringBuilder state = new StringBuilder();

            state.Append("name = [" + name + "] ");

            return state.ToString();
        }
    }

    /// <summary>
    /// Ticket class
    /// </summary>
    public abstract class Ticket : IComparable
    {
        private string number;

        /// <summary>
        /// Number property
        /// </summary>
        public string Number
        {
            get
            {
                return number;
            }
            set
            {
               number = value;
            }
        }

        private string type;

        /// <summary>
        /// Type property
        /// </summary>
        public string Type
        {
            get
            {
                return type;
            }
            set
            {
               type = value;
            }
        }

        private string status;

        /// <summary>
        /// Status property
        /// </summary>
        public string Status
        {
            get
            {
                return status;
            }
            set
            {
               status = value;
            }
        }

        private string requestMode;

        /// <summary>
        /// RequestMode property
        /// </summary>
        public string RequestMode
        {
            get
            {
                return requestMode;
            }
            set
            {
               requestMode = value;
            }
        }

        private string description;

        /// <summary>
        /// Description property
        /// </summary>
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
               description = value;
            }
        }

        private string notes;

        /// <summary>
        /// Notes property
        /// </summary>
        public string Notes
        {
            get
            {
                return notes;
            }
            set
            {
               notes = value;
            }
        }

        private string requestersNumber;

        /// <summary>
        /// RequestersNumber property
        /// </summary>
        public string RequestersNumber
        {
            get
            {
                return requestersNumber;
            }
            set
            {
               requestersNumber = value;
            }
        }

        private string agentsNumber;

        /// <summary>
        /// AgentsNumber property
        /// </summary>
        public string AgentsNumber
        {
            get
            {
                return agentsNumber;
            }
            set
            {
               agentsNumber = value;
            }
        }

        private string impact;

        /// <summary>
        /// Impact property
        /// </summary>
        public string Impact
        {
            get
            {
                return impact;
            }
            set
            {
               impact = value;
            }
        }

        private string urgency;

        /// <summary>
        /// Urgency property
        /// </summary>
        public string Urgency
        {
            get
            {
                return urgency;
            }
            set
            {
               urgency = value;
            }
        }

        private string priority;

        /// <summary>
        /// Priority property
        /// </summary>
        public string Priority
        {
            get
            {
                return priority;
            }
            set
            {
               priority = value;
            }
        }

        /// <summary>
        /// Compare this Ticket object to another for sorting
        /// </summary>
        /// <param name="compareObject">Object to compare with this one</param>
        /// <returns>A negative number, 1, or a positive integer</returns>
        public int CompareTo(Object compareObject)
        {
            Ticket compareTicket = (Ticket) compareObject;

            string thisKey = "Change to the desired key";
            string compareKey = "Change to the desired key";

            return thisKey.CompareTo(compareKey);
        }

        /// <summary>
        /// Return a string that shows the current state of this Ticket object
        /// </summary>
        /// <returns>Object state</returns>
        public override string ToString()
        {
            StringBuilder state = new StringBuilder();

            state.Append("number = [" + number + "] ");
            state.Append("type = [" + type + "] ");
            state.Append("status = [" + status + "] ");
            state.Append("requestMode = [" + requestMode + "] ");
            state.Append("description = [" + description + "] ");
            state.Append("notes = [" + notes + "] ");
            state.Append("requestersNumber = [" + requestersNumber + "] ");
            state.Append("agentsNumber = [" + agentsNumber + "] ");
            state.Append("impact = [" + impact + "] ");
            state.Append("urgency = [" + urgency + "] ");
            state.Append("priority = [" + priority + "] ");

            return state.ToString();
        }
    }

    /// <summary>
    /// Incident class
    /// </summary>
    public class Incident : IComparable, Ticket
    {
        private string errorRecord;

        /// <summary>
        /// ErrorRecord property
        /// </summary>
        public string ErrorRecord
        {
            get
            {
                return errorRecord;
            }
            set
            {
               errorRecord = value;
            }
        }

        /// <summary>
        /// Compare this Incident object to another for sorting
        /// </summary>
        /// <param name="compareObject">Object to compare with this one</param>
        /// <returns>A negative number, 1, or a positive integer</returns>
        public int CompareTo(Object compareObject)
        {
            Incident compareIncident = (Incident) compareObject;

            string thisKey = "Change to the desired key";
            string compareKey = "Change to the desired key";

            return thisKey.CompareTo(compareKey);
        }

        /// <summary>
        /// Return a string that shows the current state of this Incident object
        /// </summary>
        /// <returns>Object state</returns>
        public override string ToString()
        {
            StringBuilder state = new StringBuilder();

            state.Append("errorRecord = [" + errorRecord + "] ");

            return state.ToString();
        }
    }

    /// <summary>
    /// ServiceRequest class
    /// </summary>
    public class ServiceRequest : IComparable, Ticket
    {
        private string itemID;

        /// <summary>
        /// ItemID property
        /// </summary>
        public string ItemID
        {
            get
            {
                return itemID;
            }
            set
            {
               itemID = value;
            }
        }

        private string levelAgreeID;

        /// <summary>
        /// LevelAgreeID property
        /// </summary>
        public string LevelAgreeID
        {
            get
            {
                return levelAgreeID;
            }
            set
            {
               levelAgreeID = value;
            }
        }

        /// <summary>
        /// Compare this ServiceRequest object to another for sorting
        /// </summary>
        /// <param name="compareObject">Object to compare with this one</param>
        /// <returns>A negative number, 1, or a positive integer</returns>
        public int CompareTo(Object compareObject)
        {
            ServiceRequest compareServiceRequest = (ServiceRequest) compareObject;

            string thisKey = "Change to the desired key";
            string compareKey = "Change to the desired key";

            return thisKey.CompareTo(compareKey);
        }

        /// <summary>
        /// Return a string that shows the current state of this ServiceRequest object
        /// </summary>
        /// <returns>Object state</returns>
        public override string ToString()
        {
            StringBuilder state = new StringBuilder();

            state.Append("itemID = [" + itemID + "] ");
            state.Append("levelAgreeID = [" + levelAgreeID + "] ");

            return state.ToString();
        }
    }

    /// <summary>
    /// Change class
    /// </summary>
    public class Change : IComparable, Ticket
    {
        private string changeCategory;

        /// <summary>
        /// ChangeCategory property
        /// </summary>
        public string ChangeCategory
        {
            get
            {
                return changeCategory;
            }
            set
            {
               changeCategory = value;
            }
        }

        private string changeRisk;

        /// <summary>
        /// ChangeRisk property
        /// </summary>
        public string ChangeRisk
        {
            get
            {
                return changeRisk;
            }
            set
            {
               changeRisk = value;
            }
        }

        private string reason;

        /// <summary>
        /// Reason property
        /// </summary>
        public string Reason
        {
            get
            {
                return reason;
            }
            set
            {
               reason = value;
            }
        }

        private string implications;

        /// <summary>
        /// Implications property
        /// </summary>
        public string Implications
        {
            get
            {
                return implications;
            }
            set
            {
               implications = value;
            }
        }

        private string rolloutPlan;

        /// <summary>
        /// RolloutPlan property
        /// </summary>
        public string RolloutPlan
        {
            get
            {
                return rolloutPlan;
            }
            set
            {
               rolloutPlan = value;
            }
        }

        private string backoutPlan;

        /// <summary>
        /// BackoutPlan property
        /// </summary>
        public string BackoutPlan
        {
            get
            {
                return backoutPlan;
            }
            set
            {
               backoutPlan = value;
            }
        }

        private string approvals;

        /// <summary>
        /// Approvals property
        /// </summary>
        public string Approvals
        {
            get
            {
                return approvals;
            }
            set
            {
               approvals = value;
            }
        }

        private string releaseInfo;

        /// <summary>
        /// ReleaseInfo property
        /// </summary>
        public string ReleaseInfo
        {
            get
            {
                return releaseInfo;
            }
            set
            {
               releaseInfo = value;
            }
        }

        /// <summary>
        /// Compare this Change object to another for sorting
        /// </summary>
        /// <param name="compareObject">Object to compare with this one</param>
        /// <returns>A negative number, 1, or a positive integer</returns>
        public int CompareTo(Object compareObject)
        {
            Change compareChange = (Change) compareObject;

            string thisKey = "Change to the desired key";
            string compareKey = "Change to the desired key";

            return thisKey.CompareTo(compareKey);
        }

        /// <summary>
        /// Return a string that shows the current state of this Change object
        /// </summary>
        /// <returns>Object state</returns>
        public override string ToString()
        {
            StringBuilder state = new StringBuilder();

            state.Append("changeCategory = [" + changeCategory + "] ");
            state.Append("changeRisk = [" + changeRisk + "] ");
            state.Append("reason = [" + reason + "] ");
            state.Append("implications = [" + implications + "] ");
            state.Append("rolloutPlan = [" + rolloutPlan + "] ");
            state.Append("backoutPlan = [" + backoutPlan + "] ");
            state.Append("approvals = [" + approvals + "] ");
            state.Append("releaseInfo = [" + releaseInfo + "] ");

            return state.ToString();
        }
    }

    /// <summary>
    /// Problems class
    /// </summary>
    public class Problems : IComparable, Ticket
    {
        private string rootCause;

        /// <summary>
        /// RootCause property
        /// </summary>
        public string RootCause
        {
            get
            {
                return rootCause;
            }
            set
            {
               rootCause = value;
            }
        }

        private string symptoms;

        /// <summary>
        /// Symptoms property
        /// </summary>
        public string Symptoms
        {
            get
            {
                return symptoms;
            }
            set
            {
               symptoms = value;
            }
        }

        private string permSolutionTitle;

        /// <summary>
        /// PermSolutionTitle property
        /// </summary>
        public string PermSolutionTitle
        {
            get
            {
                return permSolutionTitle;
            }
            set
            {
               permSolutionTitle = value;
            }
        }

        private string permSolutionDesc;

        /// <summary>
        /// PermSolutionDesc property
        /// </summary>
        public string PermSolutionDesc
        {
            get
            {
                return permSolutionDesc;
            }
            set
            {
               permSolutionDesc = value;
            }
        }

        private string workSolutionTitle;

        /// <summary>
        /// WorkSolutionTitle property
        /// </summary>
        public string WorkSolutionTitle
        {
            get
            {
                return workSolutionTitle;
            }
            set
            {
               workSolutionTitle = value;
            }
        }

        private string workSolutionDesc;

        /// <summary>
        /// WorkSolutionDesc property
        /// </summary>
        public string WorkSolutionDesc
        {
            get
            {
                return workSolutionDesc;
            }
            set
            {
               workSolutionDesc = value;
            }
        }

        /// <summary>
        /// Compare this Problems object to another for sorting
        /// </summary>
        /// <param name="compareObject">Object to compare with this one</param>
        /// <returns>A negative number, 1, or a positive integer</returns>
        public int CompareTo(Object compareObject)
        {
            Problems compareProblems = (Problems) compareObject;

            string thisKey = "Change to the desired key";
            string compareKey = "Change to the desired key";

            return thisKey.CompareTo(compareKey);
        }

        /// <summary>
        /// Return a string that shows the current state of this Problems object
        /// </summary>
        /// <returns>Object state</returns>
        public override string ToString()
        {
            StringBuilder state = new StringBuilder();

            state.Append("rootCause = [" + rootCause + "] ");
            state.Append("symptoms = [" + symptoms + "] ");
            state.Append("permSolutionTitle = [" + permSolutionTitle + "] ");
            state.Append("permSolutionDesc = [" + permSolutionDesc + "] ");
            state.Append("workSolutionTitle = [" + workSolutionTitle + "] ");
            state.Append("workSolutionDesc = [" + workSolutionDesc + "] ");

            return state.ToString();
        }
    }

    /// <summary>
    /// Employee class
    /// </summary>
    public abstract class Employee : IComparable
    {
        private string number;

        /// <summary>
        /// Number property
        /// </summary>
        public string Number
        {
            get
            {
                return number;
            }
            set
            {
               number = value;
            }
        }

        private string lastName;

        /// <summary>
        /// LastName property
        /// </summary>
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
               lastName = value;
            }
        }

        private string firstName;

        /// <summary>
        /// FirstName property
        /// </summary>
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
               firstName = value;
            }
        }

        private string middleName;

        /// <summary>
        /// MiddleName property
        /// </summary>
        public string MiddleName
        {
            get
            {
                return middleName;
            }
            set
            {
               middleName = value;
            }
        }

        private string department;

        /// <summary>
        /// Department property
        /// </summary>
        public string Department
        {
            get
            {
                return department;
            }
            set
            {
               department = value;
            }
        }

        private string position;

        /// <summary>
        /// Position property
        /// </summary>
        public string Position
        {
            get
            {
                return position;
            }
            set
            {
               position = value;
            }
        }

        private string location;

        /// <summary>
        /// Location property
        /// </summary>
        public string Location
        {
            get
            {
                return location;
            }
            set
            {
               location = value;
            }
        }

        private string workPhoneNumber;

        /// <summary>
        /// WorkPhoneNumber property
        /// </summary>
        public string WorkPhoneNumber
        {
            get
            {
                return workPhoneNumber;
            }
            set
            {
               workPhoneNumber = value;
            }
        }

        private string phoneExtension;

        /// <summary>
        /// PhoneExtension property
        /// </summary>
        public string PhoneExtension
        {
            get
            {
                return phoneExtension;
            }
            set
            {
               phoneExtension = value;
            }
        }

        private string workEmail;

        /// <summary>
        /// WorkEmail property
        /// </summary>
        public string WorkEmail
        {
            get
            {
                return workEmail;
            }
            set
            {
               workEmail = value;
            }
        }

        private string imageFileName;

        /// <summary>
        /// ImageFileName property
        /// </summary>
        public string ImageFileName
        {
            get
            {
                return imageFileName;
            }
            set
            {
               imageFileName = value;
            }
        }

        private string imageFileEmployee;

        /// <summary>
        /// ImageFileEmployee property
        /// </summary>
        public string ImageFileEmployee
        {
            get
            {
                return imageFileEmployee;
            }
            set
            {
               imageFileEmployee = value;
            }
        }

        private string notes;

        /// <summary>
        /// Notes property
        /// </summary>
        public string Notes
        {
            get
            {
                return notes;
            }
            set
            {
               notes = value;
            }
        }

        /// <summary>
        /// Compare this Employee object to another for sorting
        /// </summary>
        /// <param name="compareObject">Object to compare with this one</param>
        /// <returns>A negative number, 1, or a positive integer</returns>
        public int CompareTo(Object compareObject)
        {
            Employee compareEmployee = (Employee) compareObject;

            string thisKey = "Change to the desired key";
            string compareKey = "Change to the desired key";

            return thisKey.CompareTo(compareKey);
        }

        /// <summary>
        /// Return a string that shows the current state of this Employee object
        /// </summary>
        /// <returns>Object state</returns>
        public override string ToString()
        {
            StringBuilder state = new StringBuilder();

            state.Append("number = [" + number + "] ");
            state.Append("lastName = [" + lastName + "] ");
            state.Append("firstName = [" + firstName + "] ");
            state.Append("middleName = [" + middleName + "] ");
            state.Append("department = [" + department + "] ");
            state.Append("position = [" + position + "] ");
            state.Append("location = [" + location + "] ");
            state.Append("workPhoneNumber = [" + workPhoneNumber + "] ");
            state.Append("phoneExtension = [" + phoneExtension + "] ");
            state.Append("workEmail = [" + workEmail + "] ");
            state.Append("imageFileName = [" + imageFileName + "] ");
            state.Append("imageFileEmployee = [" + imageFileEmployee + "] ");
            state.Append("notes = [" + notes + "] ");

            return state.ToString();
        }
    }

    /// <summary>
    /// Location class
    /// </summary>
    public class Location : IComparable
    {
        private string name;

        /// <summary>
        /// Name property
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
               name = value;
            }
        }

        /// <summary>
        /// Compare this Location object to another for sorting
        /// </summary>
        /// <param name="compareObject">Object to compare with this one</param>
        /// <returns>A negative number, 1, or a positive integer</returns>
        public int CompareTo(Object compareObject)
        {
            Location compareLocation = (Location) compareObject;

            string thisKey = "Change to the desired key";
            string compareKey = "Change to the desired key";

            return thisKey.CompareTo(compareKey);
        }

        /// <summary>
        /// Return a string that shows the current state of this Location object
        /// </summary>
        /// <returns>Object state</returns>
        public override string ToString()
        {
            StringBuilder state = new StringBuilder();

            state.Append("name = [" + name + "] ");

            return state.ToString();
        }
    }

    /// <summary>
    /// Department class
    /// </summary>
    public class Department : IComparable
    {
        private string name;

        /// <summary>
        /// Name property
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
               name = value;
            }
        }

        /// <summary>
        /// Compare this Department object to another for sorting
        /// </summary>
        /// <param name="compareObject">Object to compare with this one</param>
        /// <returns>A negative number, 1, or a positive integer</returns>
        public int CompareTo(Object compareObject)
        {
            Department compareDepartment = (Department) compareObject;

            string thisKey = "Change to the desired key";
            string compareKey = "Change to the desired key";

            return thisKey.CompareTo(compareKey);
        }

        /// <summary>
        /// Return a string that shows the current state of this Department object
        /// </summary>
        /// <returns>Object state</returns>
        public override string ToString()
        {
            StringBuilder state = new StringBuilder();

            state.Append("name = [" + name + "] ");

            return state.ToString();
        }
    }

    /// <summary>
    /// Position class
    /// </summary>
    public class Position : IComparable
    {
        private string name;

        /// <summary>
        /// Name property
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
               name = value;
            }
        }

        /// <summary>
        /// Compare this Position object to another for sorting
        /// </summary>
        /// <param name="compareObject">Object to compare with this one</param>
        /// <returns>A negative number, 1, or a positive integer</returns>
        public int CompareTo(Object compareObject)
        {
            Position comparePosition = (Position) compareObject;

            string thisKey = "Change to the desired key";
            string compareKey = "Change to the desired key";

            return thisKey.CompareTo(compareKey);
        }

        /// <summary>
        /// Return a string that shows the current state of this Position object
        /// </summary>
        /// <returns>Object state</returns>
        public override string ToString()
        {
            StringBuilder state = new StringBuilder();

            state.Append("name = [" + name + "] ");

            return state.ToString();
        }
    }

    /// <summary>
    /// Requester class
    /// </summary>
    public class Requester : IComparable, Employee
    {
        private string employeeNumber;

        /// <summary>
        /// EmployeeNumber property
        /// </summary>
        public string EmployeeNumber
        {
            get
            {
                return employeeNumber;
            }
            set
            {
               employeeNumber = value;
            }
        }

        private string businessImpact;

        /// <summary>
        /// BusinessImpact property
        /// </summary>
        public string BusinessImpact
        {
            get
            {
                return businessImpact;
            }
            set
            {
               businessImpact = value;
            }
        }

        private string VIPFlag;

        /// <summary>
        /// VIPFlag property
        /// </summary>
        public string VIPFlag
        {
            get
            {
                return VIPFlag;
            }
            set
            {
               VIPFlag = value;
            }
        }

        private string approver;

        /// <summary>
        /// Approver property
        /// </summary>
        public string Approver
        {
            get
            {
                return approver;
            }
            set
            {
               approver = value;
            }
        }

        /// <summary>
        /// Compare this Requester object to another for sorting
        /// </summary>
        /// <param name="compareObject">Object to compare with this one</param>
        /// <returns>A negative number, 1, or a positive integer</returns>
        public int CompareTo(Object compareObject)
        {
            Requester compareRequester = (Requester) compareObject;

            string thisKey = "Change to the desired key";
            string compareKey = "Change to the desired key";

            return thisKey.CompareTo(compareKey);
        }

        /// <summary>
        /// Return a string that shows the current state of this Requester object
        /// </summary>
        /// <returns>Object state</returns>
        public override string ToString()
        {
            StringBuilder state = new StringBuilder();

            state.Append("employeeNumber = [" + employeeNumber + "] ");
            state.Append("businessImpact = [" + businessImpact + "] ");
            state.Append("VIPFlag = [" + VIPFlag + "] ");
            state.Append("approver = [" + approver + "] ");

            return state.ToString();
        }
    }

    /// <summary>
    /// AgentConfidential class
    /// </summary>
    public class AgentConfidential : IComparable
    {
        private string privatePhoneNumber;

        /// <summary>
        /// PrivatePhoneNumber property
        /// </summary>
        public string PrivatePhoneNumber
        {
            get
            {
                return privatePhoneNumber;
            }
            set
            {
               privatePhoneNumber = value;
            }
        }

        private string privateEmail;

        /// <summary>
        /// PrivateEmail property
        /// </summary>
        public string PrivateEmail
        {
            get
            {
                return privateEmail;
            }
            set
            {
               privateEmail = value;
            }
        }

        /// <summary>
        /// Compare this AgentConfidential object to another for sorting
        /// </summary>
        /// <param name="compareObject">Object to compare with this one</param>
        /// <returns>A negative number, 1, or a positive integer</returns>
        public int CompareTo(Object compareObject)
        {
            AgentConfidential compareAgentConfidential = (AgentConfidential) compareObject;

            string thisKey = "Change to the desired key";
            string compareKey = "Change to the desired key";

            return thisKey.CompareTo(compareKey);
        }

        /// <summary>
        /// Return a string that shows the current state of this AgentConfidential object
        /// </summary>
        /// <returns>Object state</returns>
        public override string ToString()
        {
            StringBuilder state = new StringBuilder();

            state.Append("privatePhoneNumber = [" + privatePhoneNumber + "] ");
            state.Append("privateEmail = [" + privateEmail + "] ");

            return state.ToString();
        }
    }

    /// <summary>
    /// Agent class
    /// </summary>
    public class Agent : IComparable, Employee
    {
        private string serviceTier;

        /// <summary>
        /// ServiceTier property
        /// </summary>
        public string ServiceTier
        {
            get
            {
                return serviceTier;
            }
            set
            {
               serviceTier = value;
            }
        }

        /// <summary>
        /// Compare this Agent object to another for sorting
        /// </summary>
        /// <param name="compareObject">Object to compare with this one</param>
        /// <returns>A negative number, 1, or a positive integer</returns>
        public int CompareTo(Object compareObject)
        {
            Agent compareAgent = (Agent) compareObject;

            string thisKey = "Change to the desired key";
            string compareKey = "Change to the desired key";

            return thisKey.CompareTo(compareKey);
        }

        /// <summary>
        /// Return a string that shows the current state of this Agent object
        /// </summary>
        /// <returns>Object state</returns>
        public override string ToString()
        {
            StringBuilder state = new StringBuilder();

            state.Append("serviceTier = [" + serviceTier + "] ");

            return state.ToString();
        }
    }

    /// <summary>
    /// ServiceTeam class
    /// </summary>
    public class ServiceTeam : IComparable
    {
        private string name;

        /// <summary>
        /// Name property
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
               name = value;
            }
        }

        /// <summary>
        /// Compare this ServiceTeam object to another for sorting
        /// </summary>
        /// <param name="compareObject">Object to compare with this one</param>
        /// <returns>A negative number, 1, or a positive integer</returns>
        public int CompareTo(Object compareObject)
        {
            ServiceTeam compareServiceTeam = (ServiceTeam) compareObject;

            string thisKey = "Change to the desired key";
            string compareKey = "Change to the desired key";

            return thisKey.CompareTo(compareKey);
        }

        /// <summary>
        /// Return a string that shows the current state of this ServiceTeam object
        /// </summary>
        /// <returns>Object state</returns>
        public override string ToString()
        {
            StringBuilder state = new StringBuilder();

            state.Append("name = [" + name + "] ");

            return state.ToString();
        }
    }

    /// <summary>
    /// AgentServiceTeam class
    /// </summary>
    public class AgentServiceTeam : IComparable
    {
        private string teamName;

        /// <summary>
        /// TeamName property
        /// </summary>
        public string TeamName
        {
            get
            {
                return teamName;
            }
            set
            {
               teamName = value;
            }
        }

        private string employeeNumber;

        /// <summary>
        /// EmployeeNumber property
        /// </summary>
        public string EmployeeNumber
        {
            get
            {
                return employeeNumber;
            }
            set
            {
               employeeNumber = value;
            }
        }

        /// <summary>
        /// Compare this AgentServiceTeam object to another for sorting
        /// </summary>
        /// <param name="compareObject">Object to compare with this one</param>
        /// <returns>A negative number, 1, or a positive integer</returns>
        public int CompareTo(Object compareObject)
        {
            AgentServiceTeam compareAgentServiceTeam = (AgentServiceTeam) compareObject;

            string thisKey = "Change to the desired key";
            string compareKey = "Change to the desired key";

            return thisKey.CompareTo(compareKey);
        }

        /// <summary>
        /// Return a string that shows the current state of this AgentServiceTeam object
        /// </summary>
        /// <returns>Object state</returns>
        public override string ToString()
        {
            StringBuilder state = new StringBuilder();

            state.Append("teamName = [" + teamName + "] ");
            state.Append("employeeNumber = [" + employeeNumber + "] ");

            return state.ToString();
        }
    }

}
