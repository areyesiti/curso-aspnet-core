using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreGram.Migrations
{
    public partial class GetLikesByPostSP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            {
                var sp = @"CREATE PROCEDURE [dbo].[sp_GetLikesByPost]
                    @postId int,
                    @total int OUT
                AS
                BEGIN
                    SELECT @total = COUNT(PostId) FROM Likes WHERE PostId = @postId
                END";

                migrationBuilder.Sql(sp);
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
