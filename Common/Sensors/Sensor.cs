using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Common;
using Common.Interfaces;

namespace Common.Sensors
{
	public class Sensor : ISensor
	{
		private readonly int delay ;
		private readonly IInformationSource informationSource;
		private readonly IRule rule;
		private IReportAgent reportAgent;

		public Sensor(IInformationSource infoSource, IRule idsRule, IReportAgent reportAgent) : this(infoSource, idsRule)
		{
			this.reportAgent = reportAgent;
		}

		public Sensor(IInformationSource infoSource, IRule idsRule)
		{
			informationSource = infoSource;
			rule = idsRule;
			delay = 1000;
		}

		public int UnreadBufferCount => informationSource.BufferCount;

		public bool ProcessNextMessage()
		{
			NetworkEventArgs message = informationSource.GetNextMessage();

			if (rule.Match(message) && reportAgent != null)
				reportAgent.ReportPacketCaptured(message);

			return rule.Match(message);
		}

		public IInformationSource InformationSource { get { return informationSource; } set { throw new NotImplementedException(); } }

		public void Start()
		{
			IntialiseInformationSource(informationSource as dynamic);
				
			//Poll information source periodically to process the next message
			var listener = Task.Factory.StartNew(() =>{
				while (true)
				{
					ProcessNextMessage();
					Thread.Sleep(delay);
				}
			});
		}

		public void StartCapturing(){
			throw new NotImplementedException();
		}

		public void StopCapturing(){
			throw new NotImplementedException();
		}

        public string GetSensorId(){
			throw new NotImplementedException();
		}

		private void IntialiseInformationSource(IActiveInformationSource activeInformationSource)
		{
			 activeInformationSource.StartListening();
		}

		private void IntialiseInformationSource(IInformationSource informationSource)
		{
			
		}
	}
}