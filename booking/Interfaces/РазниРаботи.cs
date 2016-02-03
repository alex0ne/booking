namespace HotelBookingSystem.Interfaces
{
    // Ever wondered about the difference between I...able and I...er? Here it is :)
    public interface IFCkable
    {
        void GetF_cked();
    }

    public interface IFCker
    {
        void F_ck(IFCkable target);
    }
}