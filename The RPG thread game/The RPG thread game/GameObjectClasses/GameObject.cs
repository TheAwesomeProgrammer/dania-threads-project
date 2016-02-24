using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_RPG_thread_game.GameObjectClasses.ThreadObjects;
using The_RPG_thread_game.Utillity;

namespace The_RPG_thread_game
{
    public abstract class GameObject
    {
       
        public bool IsThreadable;
        public bool IsDead;

        protected Vector2 StartPos;

        protected bool IsFirstRun = true;

        private int Id;

        public Vector2 Position;
    


        public GameObject(Vector2 startPos)
        {
            Id = IDManager.Instance.GetID();
            StartPos = startPos;
            Position = startPos;
        }

        public virtual void Update(double deltaTime)
        {
            if (IsFirstRun)
            {
                IsFirstRun = false;
                Init();
            }
        }

        public virtual void UpdateAnimation(double deltaTime)
        {
        }

        protected virtual void Init()
        {

        }

        public  int GetObjectId()
        {
            return Id;
        }


        public virtual void Die()
        {
            GameWorld.RemoveObjectInNextCycle(this);
            IsDead = true;
        }


    }
}