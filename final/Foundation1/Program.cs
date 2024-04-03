class Program
{
    static void Main(string[] args)
    {
        // Create video instances
        Video video1 = new Video("Introduction to C#", "Programming Guru", 300);
        Video video2 = new Video("Getting Started with ASP.NET Core", "Web Development Master", 480);
        Video video3 = new Video("Data Structures and Algorithms Crash Course", "Code Ninja", 600);

        // Add comments to videos
        video1.AddComment("John", "Great tutorial! Very helpful.");
        video1.AddComment("Alice", "Thanks for explaining this concept.");
        video2.AddComment("Bob", "Can you make a video on advanced topics?");
        video3.AddComment("Sarah", "Awesome content! Learned a lot.");

        // Store videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display details of each video
        foreach (Video video in videos)
        {
            video.DisplayDetails();
        }
    }
}
