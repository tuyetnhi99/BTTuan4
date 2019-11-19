using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using ProjectMVVM_Floweronline.Models;
using ProjectMVVM_Floweronline.Interface;
using ProjectMVVM_Floweronline.Reponsitory;
using System.Windows.Input;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace ProjectMVVM_Floweronline.ViewModels
{
    public class LoaihoaViewModel : INotifyPropertyChanged
    {
        private Loaihoa loaihoa;
        public ILoaihoaRepository loaihoaRepository;
        public ICommand AddLoaiHoa { get; private set; }
        public ICommand UpdateLoaiHoa { get; private set; }
        public ICommand DeleteLoaiHoa { get; private set; }
        public LoaihoaViewModel()
        {
            loaihoaRepository = new LoaiHoaRepository();
            LoadLoaihao();
            AddLoaiHoa = new Command(Insert);
            UpdateLoaiHoa = new Command(Update, CanExe);
            DeleteLoaiHoa = new Command(Delete, CanExe);
            loaihoa = new Loaihoa();

        }
        private void Delete()
        {
            loaihoaRepository.Delete(Loaihoa);
            LoadLoaihao();
        }
        private bool CanExe()
        {
            if (Loaihoa == null || Loaihoa.Maloai == 0)
                return false;
            else
                return true;
        }
        private void Update()
        {
            loaihoaRepository.Update(Loaihoa);
            LoadLoaihao();
        }
        public Loaihoa Loaihoa
        {
            get { return loaihoa; }
            set { loaihoa = value;
                RaisePropertyChanged("Loaihoa");
                ((Command)UpdateLoaiHoa).ChangeCanExecute();
            }
        }
        private void Insert()
        {
            loaihoaRepository.Insert(loaihoa);
            LoadLoaihao();
        }
        public int Maloai
        {
            get { return loaihoa.Maloai; }
            set { loaihoa.Maloai = value;
                RaisePropertyChanged("Maloai");
                }
        }
        public string Tenloai { get { return loaihoa.Tenloai; }
        set { loaihoa.Tenloai = value;
                RaisePropertyChanged("Tenloai");
            }
        }

        ObservableCollection<Loaihoa> loaihoalist;
        public ObservableCollection<Loaihoa> Loaihoalist
        {
            get { return loaihoalist; }
            set
            {
                loaihoalist = value;
                RaisePropertyChanged("Loaihoalist");
            }
        }
        void LoadLoaihao()
        {
            Loaihoalist = loaihoaRepository.GetLoaihoas();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }

    }
}
