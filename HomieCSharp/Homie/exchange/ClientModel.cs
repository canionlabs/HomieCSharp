using System;
namespace Homie.exchange
{
	public interface IClientModel
	{
		/// <summary>
		/// Subscribe the specified topic with the handler callback
		/// </summary>
		/// <param name="topic">Topic to subscribe.</param>
		/// <param name="handler">Data handler. First argument is the topic, second is the data</param>
		void Subscribe(string topic, Action<string, string> handler);

		/// <summary>
		/// Publish data to the specified topic
		/// </summary>
		/// <param name="topic">Topic.</param>
		/// <param name="data">Data.</param>
		void Publish(string topic, string data);
	}
}
