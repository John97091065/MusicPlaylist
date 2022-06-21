using System;
using System.Data;

namespace MusicPlaylist.Code.XML
{
    public class SongMethods
    {
        private DataSet ds = new DataSet("playlist");

        public DataSet GetAllSongs(string file)
        {
            DataTable dtSongs = new DataTable("song");

            DataColumn dcId = new DataColumn("id");
            DataColumn dcArtist = new DataColumn("artist");
            DataColumn dcTitle = new DataColumn("title");
            DataColumn dcYear = new DataColumn("year");
            DataColumn dcGenre = new DataColumn("genre");
            DataColumn dcTime = new DataColumn("time");

            dtSongs.Columns.Add(dcId);
            dtSongs.Columns.Add(dcArtist);
            dtSongs.Columns.Add(dcTitle);
            dtSongs.Columns.Add(dcYear);
            dtSongs.Columns.Add(dcGenre);
            dtSongs.Columns.Add(dcTime);
            
            ds.Tables.Add(dtSongs);

            ds.ReadXml(Environment.CurrentDirectory + file);
            return ds;
        }

        public DataRow GetEmptyDataRow()
        {
            DataRow dr = ds.Tables["song"].NewRow();
            return dr;
        }

        public void CreateSong(DataRow dr, string file)
        {
            ds.Tables["song"].Rows.Add(dr);
            ds.WriteXml(Environment.CurrentDirectory + file);
        }

        public void DeleteSong(string id, string file)
        {
            DataRow[] drSongs = ds.Tables["song"].Select("id = '" + id + "'");
            if (drSongs != null && drSongs.Length > 0)
            {
                drSongs[0].Delete();
                ds.WriteXml (Environment.CurrentDirectory + file);
            }
        }

        public void ChangeSong(string id, string file)
        {
            DataRow[] drSongs = ds.Tables["song"].Select("id = '" + id + "'");
            if (drSongs != null && drSongs.Length > 0)
            {
                drSongs[0].AcceptChanges();
                ds.WriteXml (Environment.CurrentDirectory + file);
            }
        }
    }

}
