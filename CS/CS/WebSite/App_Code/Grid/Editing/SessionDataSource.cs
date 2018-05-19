using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public class DxUserEntry {
    int id;
    string description;
    byte[] bytes;

    public int ID {
        get { return id; }
        set { id = value; }
    }
    public string Description {
        get { return description; }
        set { description = value; }
    }
    public byte[] Bytes {
        get { return bytes; }
        set { bytes = value; }
    }

    public void Assign(DxUserEntry source) {
        Description = source.Description;
        Bytes = source.Bytes;
    }
}

public static class DxUserSessionProvider {
    const string Key = "DxUserSessionProvider";

    static HttpSessionState Session { get { return HttpContext.Current.Session; } }
    static List<DxUserEntry> Data {
        get {
            if (Session[Key] == null)
                Restore();
            return Session[Key] as List<DxUserEntry>;
        }
    }

    public static IEnumerable<DxUserEntry> Select() {
        return Data;
    }
    public static void Insert(DxUserEntry item) {
        Data.Add(item);
        item.ID = Data.Count;
    }
    public static void Update(DxUserEntry item) {
        DxUserEntry storedItem = FindItem(item.ID);
        storedItem.Assign(item);
    }
    public static void Delete(DxUserEntry item) {
        DxUserEntry storedItem = FindItem(item.ID);
        Data.Remove(storedItem);
    }
    public static void Restore() {
        Session[Key] = new List<DxUserEntry>();
    }

    public static byte[] GetImageBytes(int key) {
        DxUserEntry storedItem = FindItem(key);
        return storedItem != null ? storedItem.Bytes : null;
    }
    static DxUserEntry FindItem(int id) {
        foreach (DxUserEntry item in Data)
            if (item.ID == id)
                return item;
        return null;
    }
}
