﻿using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace YoutubeExample
{
    class VideoDAO
    {
        public List<Video> getAllVideos()
        {
            MongoClient dbClient = new MongoClient("mongodb://192.168.79.129:27017");
            IMongoDatabase db = dbClient.GetDatabase("youtube");
            var vids = db.GetCollection<BsonDocument>("videos");
            var documents = vids.Find(new BsonDocument()).ToList();
            List<Video> videos = new List<Video>();

            foreach (BsonDocument doc in documents)
            {
                Video v = new Video(doc["title"].ToString(), doc["description"].ToString());
                videos.Add(v);
            }

            return videos;
        }
    }
}
