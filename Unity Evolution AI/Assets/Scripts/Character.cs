using System;

public class Character {
    private string type;

    // public void {
        
    // }
    
    
}
public class Robber : Character {
    private string type; 
    // later down, maybe use type of robbers, ie shoplifter vs bank robber for now default
    // typical type is default
    // multiplier amongst robbers, can be increased through ML
    private float cooperation = 1f;
    //no honor amongst thieves
    private float competiveness = 1f;
    //private bool dead = false;
    //class constructor
    public Robber(string type, float cooperation, float competiveness) {
        this.type = type;
        this.cooperation = cooperation;
        this.competiveness = competiveness;
    }

    public string nameType {
        get { return type; }
        set { type = value; }
    }
    public float nameCooperation {
        get { return cooperation; }
        set { cooperation = value; } // robber2.nameCooperation = value;
    }

    public float nameCompetitveness {
        get { return competiveness; }
        set { competiveness = value; }
    }

    // public void goToFood {
        
    // }
    // public bool busted {

    // }
}

public class Cop : Character {
    private string type; // same use as robber 

    // public bool catchRobber {
    //     if (true)
        
    // }
}