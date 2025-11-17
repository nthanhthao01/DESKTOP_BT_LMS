CREATE DATABASE YoutubeApp
GO 

USE YoutubeApp
GO 

CREATE TABLE TrendingVideos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    VideoId NVARCHAR(50),
    Title NVARCHAR(255),
    ChannelTitle NVARCHAR(255),
    ViewCount BIGINT,
    LikeCount BIGINT,
    PublishedAt DATETIME,
    Description NVARCHAR(MAX),
    ThumbnailUrl NVARCHAR(500),
    NgayLay DATE
);