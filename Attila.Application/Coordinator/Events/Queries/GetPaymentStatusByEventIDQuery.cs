﻿using Attila.Application.Coordinator.Event.Queries;
using Attila.Application.Interfaces;
using Attila.Domain.Entities;
using Attila.Domain.Entities.Tables;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Event.Queries
{
    public class GetPaymentStatusByEventIDQuery : IRequest<IEnumerable<PaymentStatusVM>>
    {
        public int EventID { get; set; }

        public class GetPaymentStatusQueryHandler : IRequestHandler<GetPaymentStatusByEventIDQuery, IEnumerable<PaymentStatusVM>>
        {
            private readonly IAttilaDbContext dbContext;
            public GetPaymentStatusQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<IEnumerable<PaymentStatusVM>> Handle(GetPaymentStatusByEventIDQuery request, CancellationToken cancellationToken)
            {
                var _paymentStatus = dbContext.PaymentStatus.Where(a => a.EventDetailsID == request.EventID);



                var _listEvents = new List<PaymentStatusVM>();

                if (_paymentStatus != null)
                {

                    foreach(var item in _paymentStatus){


                        var payment = new PaymentStatusVM { 
                        Amount = item.Amount,
                        DateOfPayment = item.DateOfPayment,
                        EventDetailsID = item.EventDetailsID,
                        ReferenceNumber = item.ReferenceNumber,
                        Remarks = item.Remarks,
                        ID = item.ID
                        
                        };


                        _listEvents.Add(payment);
                        
                        }



                    return _listEvents;

                }
                else
                {
                    throw new Exception("Does not exist!");
                }

            }
        }
    }
}