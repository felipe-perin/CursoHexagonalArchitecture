﻿using Application.Ports.Infrastructure;
using Application.Ports.Interface;
using Application.Responses;
using Application.Room.Dtos;
using Application.Room.Request;
using Application.Room.Responses;
using Domain.Room.Exceptions;

namespace Application.Room
{
  public class RoomManager : IRoomManager
    {
        private readonly IRoomRepository _roomRepository;
        public RoomManager(IRoomRepository roomRepository)
        { 
            _roomRepository = roomRepository;
        }

        public async Task<RoomResponse> CreateRoom(CreateRoomRequest request)
        {
            try
            {
                var room = RoomDto.MapToEntity(request.Data);

                room.ValidateState();

                request.Data.Id = await _roomRepository.Create(room);

                return new RoomResponse
                {
                    Success = true,
                    Data = request.Data,
                };
            }
            catch (InvalidRoomDataException)
            {

                return new RoomResponse
                {
                    Success = false,
                    ErrorCode = ErrorCodes.ROOM_MISSING_REQUIRED_INFORMATION,
                    Message = "Missing required information passed"
                };
            }
            catch (Exception)
            {
                return new RoomResponse
                {
                    Success = false,
                    ErrorCode = ErrorCodes.ROOM_COULD_NOT_STORE_DATA,
                    Message = "There was an error when saving to DB"
                };
            }
        }

        public Task<RoomResponse> GetRoom(int roomId)
        {
            throw new NotImplementedException();
        }
    }
}
