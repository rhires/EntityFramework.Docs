using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Relational.Migrations.Infrastructure;
using EFGetStarted.ConsoleApp;

namespace EFGetStarted.ConsoleApp.Migrations
{
    [ContextType(typeof(BloggingContext))]
    partial class BloggingContextModelSnapshot : ModelSnapshot
    {
        public override void BuildModel(ModelBuilder builder)
        {
            builder
                .Annotation("SqlServer:DefaultSequenceName", "DefaultSequence")
                .Annotation("SqlServer:Sequence:.DefaultSequence", "'DefaultSequence', '', '1', '10', '', '', 'Int64', 'False'")
                .Annotation("SqlServer:ValueGeneration", "Sequence");
            
            builder.Entity("EFGetStarted.ConsoleApp.Blog", b =>
                {
                    b.Property<int>("BlogId")
                        .GenerateValueOnAdd()
                        .StoreGeneratedPattern(StoreGeneratedPattern.Identity);
                    
                    b.Property<string>("Url")
                        .Required();
                    
                    b.Key("BlogId");
                });
            
            builder.Entity("EFGetStarted.ConsoleApp.Post", b =>
                {
                    b.Property<int>("PostId")
                        .GenerateValueOnAdd()
                        .StoreGeneratedPattern(StoreGeneratedPattern.Identity);
                    
                    b.Property<int>("BlogId");
                    
                    b.Property<string>("Content");
                    
                    b.Property<string>("Title");
                    
                    b.Key("PostId");
                });
            
            builder.Entity("EFGetStarted.ConsoleApp.Post", b =>
                {
                    b.Reference("EFGetStarted.ConsoleApp.Blog")
                        .InverseCollection()
                        .ForeignKey("BlogId");
                });
        }
    }
}
