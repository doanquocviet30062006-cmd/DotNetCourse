using System.Collections.Generic;
public abstract class PhoneBook : Phone
{
    // Khoi tao danh sach dien thoai
    private List<KeyValuePair<string, string>> phoneList;
    public PhoneBook()
    {
        phoneList = new List<KeyValuePair<string, string>>();
    }
    // Them nguoi dung cung so dien thoai tuong ung khi chua co san
    public override void InsertPhone(string name, string phone)
    {
        phoneList.Add(new KeyValuePair<string, string>(name, phone));
    }
    // Neu ten nguoi dung co san thi kiem tra xem so dien thoai co khac so voi so da co hay khong, neu khac thi cap nhat so dien thoai moi
    public override void UpdatePhone(string name, string newphone)
    {
        for (int i = 0; i < phoneList.Count; i++)
        {
            if (phoneList[i].Key == name)
            {
                if (phoneList[i].Value != newphone)
                {
                    phoneList[i] = new KeyValuePair<string, string>(name, newphone);
                }
                return;
            }
        }
    }
    // Xoa nguoi dung theo so dien thoai
    public override void RemovePhone(string name)
    {
        phoneList.RemoveAll(p => p.Key == name);
    }
}

