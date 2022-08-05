#define PC
// #define Oculus
public static class ARAVRInput
{
    public enum Button 
    { 
        One,
        Two,
        Thumbstick,
        IndexTrigger,
        HandTrigger
    }

    public enum Controller 
    { 
        LTouch,
        Rtouch
    }

    public static bool Get(Button virtualMask, Controller hand = Controller.Rtouch);
    public static bool GetDown(Button virtualMask, Controller hand = Controller.Rtouch);
    public static GetUp(Button virtualMask, Controller hand = Controller.Rtouch);
}
