using System.Collections.Generic;
using Ulbraflix.domain.entities;

namespace Ulbraflix.domain.DTOs_e_VOs;

public record WatchHistoryRecord(List<Title> Titles);