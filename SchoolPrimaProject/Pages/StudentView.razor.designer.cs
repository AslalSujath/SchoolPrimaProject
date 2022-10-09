using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Radzen;
using SchoolPrimaProject.Model;
using SchoolPrimaProject.VM;
using PropertyChangedEventArgs = SchoolPrimaProject.Data.PropertyChangedEventArgs;

namespace SchoolPrimaProject.Pages
{
    public partial class StudentViewPageComponent : ComponentBase
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

        private IEnumerable<Marks> _Marks;

        public IEnumerable<Marks> Marks
        {
            get { return _Marks; }
            set
            {
                if (!object.Equals(_Marks, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "Marks", NewValue = value, OldValue = _Marks };
                    _Marks = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }
        private IList<MarksVM> _MarksVM=new List<MarksVM>();

        public IList<MarksVM> MarksVM
        {
            get { return _MarksVM; }
            set
            {
                if (!object.Equals(_MarksVM, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "MarksVM", NewValue = value, OldValue = _MarksVM };
                    _MarksVM = value;
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


        private IList<Studen> _SelectedStuden;

        public IList<Studen> SelectedStuden
        {
            get { return _SelectedStuden; }
            set
            {
                if (!object.Equals(_SelectedStuden, value))
                {
                    fnload();
                    var args = new PropertyChangedEventArgs() { Name = "SelectedStuden", NewValue = value, OldValue = _SelectedStuden };
                    _SelectedStuden = value;
                    OnPropertyChanged(args);
                    Reload();
                    
                }
            }
        }
 

       
        protected override async Task OnInitializedAsync()
        {
            
            fnload();

        }
        
        private async void fnload()
        {
            Schools = await Http.GetFromJsonAsync<IEnumerable<School>>("api/Marks/GetSchool");
            Marks = await Http.GetFromJsonAsync<IEnumerable<Marks>>("api/Marks/Getmark");
            Subject = await Http.GetFromJsonAsync<IEnumerable<Subject>>("api/Marks/GetSubject");

            if (SelectedSchool>0)
            {
               
                Student = await Http.GetFromJsonAsync<IEnumerable<Studen>>("api/Marks/GetStudentbySchool/"+ SelectedSchool);
            }
            else
            {
                Student = await Http.GetFromJsonAsync<IEnumerable<Studen>>("api/Marks/GetStudent");

            }
            if (SelectedStuden != null)
            {
                var sel = SelectedStuden.FirstOrDefault();
                var mk = Marks.Where(x => x.Student_Id == sel.Student_id);
                MarksVM.Clear();
                foreach (var item in mk)
                {
                    var sub = Subject.Where(x => x.Subject_id == item.Subject_id).FirstOrDefault();
                    MarksVM marksVMs = new MarksVM()
                    {
                        Subject = sub.Subject_Name,
                        Marks = item.Marks_Value
                    };
                    MarksVM.Add(marksVMs);
                }
            }
            
        }

        public async void ResetFilter()
        {
            SelectedSchool = -1;

            fnload();
        }

        public void Navig()
        {
            UriHelper.NavigateTo("addMarks");
        }




    }
}
