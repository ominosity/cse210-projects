using System;

class Program
{
    static void Main(string[] args)
    {
        // Create the videos
        Video video1 = new Video("The amazing growing basil", "G. Reen Thumb", 45);
        Video video2 = new Video("How to tile a bathtub surround", "Wally Fixer", 360);
        Video video3 = new Video("The cutest farm animals", "Old Mick Donald", 240);
        Video video4 = new Video("Lose 10% of your body weight on the Coke Zero diet", "T. Rustme", 600);

        // Create the comments for the first video
        Comment comment1 = new Comment("Drew Bious", "There's no way that's a real basil!");
        Comment comment2 = new Comment("B. R. Aggart", "My basil makes that one look like a child's toy.");
        Comment comment3 = new Comment("Addy Vertisement", "If you think that basil's amazing, you should go to http://tinyurl.com/GrowBasilBetterNow");
        Comment comment4 = new Comment("Connie Fused", "My favorite part was when the cat played with the mouse and ran into the wall where the mouse drew a picture of a tunnel.");
        // Add the comments to the first video
        video1.AddComment(comment1);
        video1.AddComment(comment2);
        video1.AddComment(comment3);
        video1.AddComment(comment4);

        // Create comments for the second video
        Comment comment5 = new Comment("N. O. Weigh", "I could never surround a bathtub with tile. Nope, never.");
        Comment comment6 = new Comment("Polly Muerr", "Tile is sooo last century. In this century, the best tub surround is made of the same stuff as the best chair, couch, and bed - plastic!");
        Comment comment7 = new Comment("Greta Tude", "This video helped answer a lot of questions I had about tiling my tub surround. Thank you for taking the time to share your expertise.");
        Comment comment8 = new Comment("H. Andy Man", "Man, I wish I had this video when I was apprenticing ten years ago. You make it look so easy!");

        // Add the comments to the second video
        video2.AddComment(comment5);
        video2.AddComment(comment6);
        video2.AddComment(comment7);
        video2.AddComment(comment8);

        // Create comments for the third video
        Comment comment9 = new Comment("Therra Duck", "E I E I O");
        Comment comment10 = new Comment("S. Nuggles", "They're so cute! I could just hug them, and squeeze them, and love them, and hug them, and squeeze them, and love them.");
        Comment comment11 = new Comment("V. Etera Nariun", "These are truly adorable, but have they been properly vaccinated?");
        Comment comment12 = new Comment("Una Employed", "The cuteness overload! I literally spent all day at work watching these cute critters over and over again. I didn't even mind when my boss sent me home 'for good this time', 'cause it gave me more time to watch this video!");

        // Add the comments to the third video
        video3.AddComment(comment9);
        video3.AddComment(comment10);
        video3.AddComment(comment11);
        video3.AddComment(comment12);

        // Create commments for the fourth video
        Comment comment13 = new Comment("Tryna Conyou", "This is great, but have I got a deal for you! Lose that stubborn belly fat with an easy exercise program. Call 1-800-Blubber and tell them Tryna sent you - I work on commission!");
        Comment comment14 = new Comment("A. Quaman", "An even better way to lose body weight is to go on the zero coke diet. Drink nothing but water and watch the pounds wash away.");
        Comment comment15 = new Comment("Stella O. Beese", "I've been drinking nothing but Coke Zero for three days and haven't noticed a difference. I call fraud.");
        Comment comment16 = new Comment("Peppy C.", "This diet is good, but your competitor puts out a better product. I'm just saying...");

        // Add the cmoments to the fourth video
        video4.AddComment(comment13);
        video4.AddComment(comment14);
        video4.AddComment(comment15);
        video4.AddComment(comment16);

        // Add the videos to a list for easy iteration
        List<Video> videoList = [video1, video2, video3, video4];

        // Clear the terminal, then iterate through the videos, displaying the description and a list ifcomments
        Console.Clear();
        foreach (Video video in videoList)
        {
            Console.WriteLine("******************************************************");
            Console.WriteLine(video.GetDescription());
            Console.WriteLine("******************************************************");
            Console.WriteLine(video.GetCommentList());
        }
    }
}