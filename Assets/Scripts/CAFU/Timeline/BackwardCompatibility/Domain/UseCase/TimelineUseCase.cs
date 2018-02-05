﻿using System;
using CAFU.Core.Domain;
using CAFU.Timeline.Domain.Model;
using UnityEngine.Playables;
#pragma warning disable 618

namespace CAFU.Timeline.Domain.UseCase {

    [Obsolete("Please use IPlayableDirectorResolver instead of this interface.")]
    public interface IPlayableDirectorResolver<in TEnum> where TEnum : struct {

        PlayableDirector GetPlayableDirector(TEnum timelineName);

    }

    [Obsolete("Please use TimelineUseCase<TTimelineModel> instead of this interface.")]
    public class TimelineUseCase<TEnum, TTimelineInformation> : IUseCase, IUseCaseBuilder
        where TEnum : struct
        where TTimelineInformation : TimelineInformation<TEnum>, new() {

        private TimelineModel<TEnum, TTimelineInformation> TimelineModel { get; set; }

        private IPlayableDirectorResolver<TEnum> PlayableDirectorResolver { get; set; }

        public void Build() {
            this.TimelineModel = new TimelineModel<TEnum, TTimelineInformation>();
        }

        public void RegisterPlayableDirectorResolver(IPlayableDirectorResolver<TEnum> playableDirectorResolver) {
            this.PlayableDirectorResolver = playableDirectorResolver;
        }

        public PlayableDirector GetPlayableDirector(TEnum name) {
            if (!this.TimelineModel.HasPlayableDirector(name)) {
                this.TimelineModel.SetTimelineInformation(name, this.PlayableDirectorResolver.GetPlayableDirector(name));
            }
            return this.TimelineModel.GetPlayableDirector(name);
        }

    }

}