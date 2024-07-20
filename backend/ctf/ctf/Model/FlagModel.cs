namespace ctf.Model;

public class FlagModel
{
    private int totalLevel = 5;
    public List<FlagOrder> reportFlag = new List<FlagOrder>();
    public List<FlagOrder> deskFlag = new List<FlagOrder>();
    public List<FlagOrder> signFlag = new List<FlagOrder>();
    public List<FlagOrder> siteFlag = new List<FlagOrder>();
    
    public FlagModel()
    {
        this.reportFlag = this.GenrateReportFlag();
        this.signFlag = this.GenerateSignFlag();
        this.deskFlag = this.GenerateDeskFlag();
        this.siteFlag = this.GenerateSiteFlag();
    }

    // Generate Report team flags.
    private List<FlagOrder> GenrateReportFlag()
    {
        List<FlagOrder> reprotFlags = new List<FlagOrder>();

        FlagOrder firstFlag = new FlagOrder()
        {
            flag = "SYNC_CTF{H3y_H4ck3r_y0u_4re_W3ll_Kn0wn_f0r_r3p0rt_" + this.GetRandomId() + "}",
            levelFlag = UserLevel.Level1
        };
        reprotFlags.Add(firstFlag);

        FlagOrder secondFlag = new FlagOrder()
        {
            flag = "SYNC_CTF{Y0u_4r3_Scr1p7_M4s73r_Woo0_w000_" + this.GetRandomId() + "}",
            levelFlag = UserLevel.Level2
        };
        reprotFlags.Add(secondFlag);

        FlagOrder thiredFlag = new FlagOrder()
        {
            flag = "SYNC_CTF{Y0u_Ar3_Co0k1e_Th31f_buddy_" + this.GetRandomId() + "}",
            levelFlag = UserLevel.Level3
        };
        reprotFlags.Add(thiredFlag);

        // need to add four and five
        FlagOrder fourthFlag = new FlagOrder()
        {
            flag = "SYNC_CTF{I_F0u4d_St3gn0_K1ng_" + this.GetRandomId() + "}",
            levelFlag = UserLevel.Level4
        };
        reprotFlags.Add(fourthFlag);
        
        FlagOrder fifthFlag = new FlagOrder()
        {
            flag = "SYNC_CTF{Y0u_4r3_Cript0nigh7_F3ar_of_Sup3r_H3r0_" + this.GetRandomId() + "}",
            levelFlag = UserLevel.Level5
        };
        reprotFlags.Add(fifthFlag);
        
        return reprotFlags;
    }

    // Generate Sign team flags.
    private List<FlagOrder> GenerateSignFlag()
    {
        List<FlagOrder> signFlags = new List<FlagOrder>();

        FlagOrder firstFlag = new FlagOrder()
        {
            flag = "SYNC_CTF{H3y_H4ck3r_y0u_4re_W3ll_Kn0wn_f0r_S1gn_" + this.GetRandomId() + "}",
            levelFlag = UserLevel.Level1
        };
        signFlags.Add(firstFlag);
        
        FlagOrder secondFlag = new FlagOrder()
        {
            flag = "SYNC_CTF{Y0u_4r3_Scr1p7_M4s73r_Woo0_w000_" + this.GetRandomId() + "}",
            levelFlag = UserLevel.Level2
        };
        signFlags.Add(secondFlag);
        
        FlagOrder thiredFlag = new FlagOrder()
        {
            flag = "SYNC_CTF{Y0u_Ar3_Co0k1e_Th31f_buddy_" + this.GetRandomId() + "}",
            levelFlag = UserLevel.Level3
        };
        signFlags.Add(thiredFlag);
        
        // need to add four and five
        FlagOrder fourthFlag = new FlagOrder()
        {
            flag = "SYNC_CTF{I_F0u4d_St3gn0_K1ng_" + this.GetRandomId() + "}",
            levelFlag = UserLevel.Level4
        };
        signFlags.Add(fourthFlag);
        
        FlagOrder fifthFlag = new FlagOrder()
        {
            flag = "SYNC_CTF{Y0u_4r3_Cript0nigh7_F3ar_of_Sup3r_H3r0_" + this.GetRandomId() + "}",
            levelFlag = UserLevel.Level5
        };
        signFlags.Add(fifthFlag);

        return signFlags;
    }

    // Generate Desk team flags.
    private List<FlagOrder> GenerateDeskFlag()
    {
        List<FlagOrder> deskFlags = new List<FlagOrder>();

        FlagOrder firstFlag = new FlagOrder()
        {
            flag = "SYNC_CTF{H3y_H4ck3r_y0u_4re_W3ll_Kn0wn_f0r_D3sK_" + this.GetRandomId() + "}",
            levelFlag = UserLevel.Level1
        };
        deskFlags.Add(firstFlag);
        
        FlagOrder secondFlag = new FlagOrder()
        {
            flag = "SYNC_CTF{Y0u_4r3_Scr1p7_M4s73r_Woo0_w000_" + this.GetRandomId() + "}",
            levelFlag = UserLevel.Level2
        };
        deskFlags.Add(secondFlag);
        
        FlagOrder thiredFlag = new FlagOrder()
        {
            flag = "SYNC_CTF{Y0u_Ar3_Co0k1e_Th31f_buddy_" + this.GetRandomId() + "}",
            levelFlag = UserLevel.Level3
        };
        deskFlags.Add(thiredFlag);

        // need to add four and five
        FlagOrder fourthFlag = new FlagOrder()
        {
            flag = "SYNC_CTF{I_F0u4d_St3gn0_K1ng_" + this.GetRandomId() + "}",
            levelFlag = UserLevel.Level4
        };
        deskFlags.Add(fourthFlag);
        
        FlagOrder fifthFlag = new FlagOrder()
        {
            flag = "SYNC_CTF{Y0u_4r3_Cript0nigh7_F3ar_of_Sup3r_H3r0_" + this.GetRandomId() + "}",
            levelFlag = UserLevel.Level5
        };
        deskFlags.Add(fifthFlag);
        
        return deskFlags;
    }

    // Generate Site team flags.
    private List<FlagOrder> GenerateSiteFlag()
    {
        List<FlagOrder> siteFlags = new List<FlagOrder>();

        FlagOrder firstFlag = new FlagOrder()
        {
            flag = "SYNC_CTF{H3y_H4ck3r_y0u_4re_W3ll_Kn0wn_f0r_S1t3s_" + this.GetRandomId() + "}",
            levelFlag = UserLevel.Level1
        };
        siteFlags.Add(firstFlag);
        
        FlagOrder secondFlag = new FlagOrder()
        {
            flag = "SYNC_CTF{Y0u_4r3_Scr1p7_M4s73r_Woo0_w000_" + this.GetRandomId() + "}",
            levelFlag = UserLevel.Level2
        };
        siteFlags.Add(secondFlag);
        
        FlagOrder thiredFlag = new FlagOrder()
        {
            flag = "SYNC_CTF{Y0u_Ar3_Co0k1e_Th31f_buddy_" + this.GetRandomId() + "}",
            levelFlag = UserLevel.Level3
        };
        siteFlags.Add(thiredFlag);
        
        // need to add four and five
        FlagOrder fourthFlag = new FlagOrder()
        {
            flag = "SYNC_CTF{I_F0u4d_St3gn0_K1ng_" + this.GetRandomId() + "}",
            levelFlag = UserLevel.Level4
        };
        siteFlags.Add(fourthFlag);
        
        FlagOrder fifthFlag = new FlagOrder()
        {
            flag = "SYNC_CTF{Y0u_4r3_Cript0nigh7_F3ar_of_Sup3r_H3r0_" + this.GetRandomId() + "}",
            levelFlag = UserLevel.Level5
        };
        siteFlags.Add(fifthFlag);
        
        return siteFlags;
    }
    
    private Guid GetRandomId()
    {
        return Guid.NewGuid();
    }
    
}

public class FlagOrder
{
    public string flag { get; set; }
    
    public UserLevel levelFlag { get; set; }
}