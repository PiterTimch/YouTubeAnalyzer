using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class addnullchannels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_video_statistics_tbl_channel_statistics_tbl_ChannelId",
                table: "video_statistics_tbl");

            migrationBuilder.AlterColumn<int>(
                name: "ChannelId",
                table: "video_statistics_tbl",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_video_statistics_tbl_channel_statistics_tbl_ChannelId",
                table: "video_statistics_tbl",
                column: "ChannelId",
                principalTable: "channel_statistics_tbl",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_video_statistics_tbl_channel_statistics_tbl_ChannelId",
                table: "video_statistics_tbl");

            migrationBuilder.AlterColumn<int>(
                name: "ChannelId",
                table: "video_statistics_tbl",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_video_statistics_tbl_channel_statistics_tbl_ChannelId",
                table: "video_statistics_tbl",
                column: "ChannelId",
                principalTable: "channel_statistics_tbl",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
