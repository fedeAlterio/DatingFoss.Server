﻿using DatingFoss.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingFoss.Application.Messages.Responses;
public class GetMessagesResponse
{
    public List<Message> Messages { get; init; } = new();
}
