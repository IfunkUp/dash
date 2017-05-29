using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Timesheeter3._0.Classes;

namespace Timesheeter3_0.Classes
{
    public class Ticket: INotifyPropertyChanged
    {
        private long m_id;

        public long id
        {
            get { return m_id; }
            set { m_id = value;
                OnPropertyChanged();
            }
        }

        private long m_assignee_id;

        public long assignee_id
        {
            get { return m_assignee_id; }
            set { m_assignee_id = value;
                OnPropertyChanged();
            }
        }
        private DateTime m_created;

        public DateTime created
        {
            get { return m_created; }
            set { m_created = value;
                OnPropertyChanged();
            }
        }
        private DateTime m_updated;

        public DateTime updated
        {
            get { return m_updated; }
            set { m_updated = value;
                OnPropertyChanged();
            }
        }
        private string m_subject;

        public string subject
        {
            get { return m_subject; }
            set { m_subject = value;
                OnPropertyChanged();
            }
        }
        private string m_status;

        public string status
        {
            get { return m_status; }
            set { m_status = value;
                OnPropertyChanged();
            }
        }
        private string m_type;

        public string type
        {
            get { return m_type; }
            set { m_type = value;
                OnPropertyChanged();
            }
        }
        private string m_tags;

        public string tags
        {
            get { return m_tags; }
            set { m_tags = value;
                OnPropertyChanged();
            }
        }
        private string m_url;

        public string url
        {
            get { return m_url; }
            set { m_url = value;
                OnPropertyChanged();

            }
        }
        private string m_via;

        public string via
        {
            get { return m_via; }
            set { m_via = value;
                OnPropertyChanged();
            }
        }
        private long m_organization_id;

        public long organization_id
        {
            get { return m_organization_id; }
            set { m_organization_id = value;
                OnPropertyChanged();
            }
        }

        private string m_Assignee_name;

        public string assignee_name
        {
            get { return m_Assignee_name; }
            set { m_Assignee_name = value;
                OnPropertyChanged();
            }
        }

        private List<Organization> m_Organizations;
        public List<Organization> Organizations
        {
            get { return m_Organizations; }
            set { m_Organizations = value;
                OnPropertyChanged();
            }
        }






        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
