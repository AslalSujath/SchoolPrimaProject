using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using SchoolPrimaProject.Model;
using SchoolPrimaProject.Data;
using PropertyChangedEventArgs = SchoolPrimaProject.Data.PropertyChangedEventArgs;
using System.Xml.Serialization;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;
using System.Text.Json.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace SchoolPrimaProject.Pages
{
    public partial class AddMarksPageComponent : ComponentBase
    {
        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, dynamic> Attributes { get; set; }

        public void Reload()
        {
            InvokeAsync(StateHasChanged);
        }

        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
        }

        [Inject]
        protected IJSRuntime JSRuntime { get; set; }
        [Inject]
        protected HttpClient Http { get; set; }

        [Inject]
        protected NavigationManager UriHelper { get; set; }

        [Inject]
        protected DialogService DialogService { get; set; }

        [Inject]
        protected TooltipService TooltipService { get; set; }

        [Inject]
        protected ContextMenuService ContextMenuService { get; set; }

        [Inject]
        protected NotificationService NotificationService { get; set; }

        private IEnumerable<School> _Schools;

        public IEnumerable<School> Schools
        {
            get { return _Schools; }
            set
            {
                if (!object.Equals(_Schools, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "Schools", NewValue = value, OldValue = _Schools };
                    _Schools = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }
        private IEnumerable<Studen> _Student;

        public IEnumerable<Studen> Student
        {
            get { return _Student; }
            set
            {
                if (!object.Equals(_Student, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "Student", NewValue = value, OldValue = _Student };
                    _Student = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }
        private IEnumerable<Subject> _Subject;

        public IEnumerable<Subject> Subject
        {
            get { return _Subject; }
            set
            {
                if (!object.Equals(_Subject, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "Student", NewValue = value, OldValue = _Subject };
                    _Subject = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        private int _SelectedSchool=-1;

        public int SelectedSchool
        {
            get { return _SelectedSchool; }
            set
            {
                if (!object.Equals(_SelectedSchool, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "SelectedSchool", NewValue = value, OldValue = _SelectedSchool };
                    _SelectedSchool = value;
                    OnPropertyChanged(args);
                    Reload();
                    fnload();
                }
                }
        }
        private int _selecedStudent=-1;

        public int SelectedStudent
        {
            get { return _selecedStudent; }
            set {
                if (!object.Equals(_selecedStudent, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "SelectedStudent", NewValue = value, OldValue = _selecedStudent };
                    _selecedStudent = value;
                    OnPropertyChanged(args);
                    Reload();
                    fnload();
                }
                }
        }
         private int _selecedSubject=-1;

        public int SelecedSubject
        {
            get { return _selecedSubject; }
            set {
                if (!object.Equals(_selecedSubject, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "SelecedSubject", NewValue = value, OldValue = _selecedSubject };
                    _selecedSubject = value;
                    OnPropertyChanged(args);
                    Reload();
                    fnload();
                }
                }
        }

        private double _marks = 0;

        public double marks
        {
            get { return _marks; }
            set
            {
                if (!object.Equals(_marks, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "marks", NewValue = value, OldValue = _marks };
                    _marks = value;
                    OnPropertyChanged(args);
                    Reload();
                    //  fnload();
                }
            }
        }
      



        protected override async Task OnInitializedAsync()
        {
            
            Schools = await Http.GetFromJsonAsync<IEnumerable<School>>("api/Marks/GetSchool");      
            

        }
        
        private async void fnload()
        {
            if (SelectedSchool>0)
            {
               
                Student = await Http.GetFromJsonAsync<IEnumerable<Studen>>("api/Marks/GetStudentbySchool/"+ SelectedSchool);
                Subject = await Http.GetFromJsonAsync<IEnumerable<Subject>>("api/Marks/GetSubject");
            }
        }

        public async Task Submit()
        {
            Marks mkr = new Marks()
            {
                Marks_Value = marks,
                Student_Id=SelectedStudent,
                Subject_id=SelecedSubject
                
            };
            //var serialized = JsonConvert.SerializeObject(mkr);
            //var stringContent = new StringContent(serialized, Encoding.UTF8, "application/json");

            //var result = await Http.PostAsync("api/Marks/Create", stringContent).ConfigureAwait(false);
            await Http.PostAsJsonAsync("api/Marks", mkr);
            NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Success, Detail = $"Save success" });

        }



    }
}
