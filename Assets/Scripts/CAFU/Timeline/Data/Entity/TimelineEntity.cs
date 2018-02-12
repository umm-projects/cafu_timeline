﻿using CAFU.Core.Data.Entity;
using UnityEngine;
using UnityEngine.Playables;

namespace CAFU.Timeline.Data.Entity {

    public interface ITimelineEntity : IEntity {

    }

    public interface ITimelineEntity<TEnum> : ITimelineEntity where TEnum : struct {

        TEnum Name { get; set; }

        PlayableDirector PlayableDirector { get; set; }

    }

    public class TimelineEntity<TEnum> : ITimelineEntity<TEnum> where TEnum : struct {

        [SerializeField]
        private TEnum name;

        public TEnum Name {
            get {
                return this.name;
            }
            set {
                this.name = value;
            }
        }

        [SerializeField]
        private PlayableDirector playableDirector;

        public PlayableDirector PlayableDirector {
            get {
                return this.playableDirector;
            }
            set {
                this.playableDirector = value;
            }
        }

    }

}